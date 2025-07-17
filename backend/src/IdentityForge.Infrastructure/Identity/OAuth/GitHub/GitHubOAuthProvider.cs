using IdentityForge.Application.Features.Auth.OAuth;

namespace IdentityForge.Infrastructure.Identity.OAuth.GitHub;

internal sealed class GitHubOAuthProvider(HttpClient http, IOptions<GitHubOAuthOptions> options) : IOAuthProvider
{
    private readonly GitHubOAuthOptions _gitHubOAuthOptions = options.Value;

    public OAuthProvider Provider => OAuthProvider.GitHub;

    public async Task<OAuthUserInfo?> ExchangeCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        var accessToken = await RequestAccessTokenAsync(code, cancellationToken);

        if (string.IsNullOrWhiteSpace(accessToken)) return null;

        http.DefaultRequestHeaders.UserAgent.ParseAdd("IdentityForge/1.0");
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var userInfo = await GetUserInfoAsync(cancellationToken);

        if (userInfo is null) return null;

        var email = await GetPrimaryEmailAsync(cancellationToken);

        if (string.IsNullOrWhiteSpace(email)) return null;

        return new OAuthUserInfo(email, userInfo.Name, userInfo.AvatarUrl);
    }

    private async Task<string?> RequestAccessTokenAsync(string code, CancellationToken cancellationToken)
    {
        var tokenRequest = new Dictionary<string, string>
        {
            ["client_id"] = _gitHubOAuthOptions.ClientId,
            ["client_secret"] = _gitHubOAuthOptions.ClientSecret,
            ["code"] = code,
            ["accept"] = "application/json",
            ["redirect_uri"] = _gitHubOAuthOptions.DefaultRedirectUrl
        };

        using var response = await http.PostAsync("https://github.com/login/oauth/access_token", new FormUrlEncodedContent(tokenRequest), cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync(cancellationToken);

        var queryParams = HttpUtility.ParseQueryString(content);

        return queryParams["access_token"];
    }

    private async Task<GitHubUserInfoResponse?> GetUserInfoAsync(CancellationToken cancellationToken)
    {
        using var response = await http.GetAsync("https://api.github.com/user", cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<GitHubUserInfoResponse>(cancellationToken);
    }

    private async Task<string?> GetPrimaryEmailAsync(CancellationToken cancellationToken)
    {
        using var response = await http.GetAsync("https://api.github.com/user/emails", cancellationToken);
        response.EnsureSuccessStatusCode();

        var emails = await response.Content.ReadFromJsonAsync<List<GitHubEmailResponse>>(cancellationToken);

        return emails?.FirstOrDefault(e => e.Primary && e.Verified)?.Email
            ?? emails?.FirstOrDefault()?.Email;
    }
}
