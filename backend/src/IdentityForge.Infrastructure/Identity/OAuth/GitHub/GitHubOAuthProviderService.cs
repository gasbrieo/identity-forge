using System.Net.Http.Headers;
using IdentityForge.Application.Identity;
using IdentityForge.Application.Identity.OAuth;

namespace IdentityForge.Infrastructure.Identity.OAuth.GitHub;

internal sealed class GitHubOAuthProviderService(HttpClient http, IOptions<GitHubOAuthOptions> options) : IOAuthProviderService
{
    private readonly GitHubOAuthOptions _gitHubOAuthOptions = options.Value;

    public OAuthProvider Provider => OAuthProvider.GitHub;

    public async Task<OAuthUserInfo?> ExchangeCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        var tokenRequest = new Dictionary<string, string>
        {
            ["code"] = code,
            ["client_id"] = _gitHubOAuthOptions.ClientId,
            ["client_secret"] = _gitHubOAuthOptions.ClientSecret,
            ["redirect_uri"] = _gitHubOAuthOptions.DefaultRedirectUri,
            ["grant_type"] = "authorization_code"
        };

        var tokenResponse = await http.PostAsync("https://github.com/login/oauth/access_token", new FormUrlEncodedContent(tokenRequest), cancellationToken);

        tokenResponse.EnsureSuccessStatusCode();

        var tokenContent = await tokenResponse.Content.ReadAsStringAsync(cancellationToken);

        var tokenQueryParams = HttpUtility.ParseQueryString(tokenContent);

        http.DefaultRequestHeaders.UserAgent.ParseAdd("IdentityForge/1.0");
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenQueryParams["access_token"]);

        var userInfoResponse = await http.GetAsync($"https://api.github.com/user", cancellationToken);

        userInfoResponse.EnsureSuccessStatusCode();

        var userInfoContent = await userInfoResponse.Content.ReadFromJsonAsync<GitHubUserInfoResponse>(cancellationToken);

        var emailResponse = await http.GetAsync("https://api.github.com/user/emails", cancellationToken);

        emailResponse.EnsureSuccessStatusCode();

        var emails = await emailResponse.Content.ReadFromJsonAsync<List<GitHubEmailResponse>>(cancellationToken);

        var email = emails?.FirstOrDefault(e => e.Primary && e.Verified)?.Email ?? emails?.FirstOrDefault()?.Email;

        return new OAuthUserInfo(email!, userInfoContent!.Name, userInfoContent.AvatarUrl);
    }
}
