using IdentityForge.Application.Identity;
using IdentityForge.Application.Identity.OAuth;

namespace IdentityForge.Infrastructure.Identity.OAuth.Google;

internal sealed class GoogleOAuthProviderService(HttpClient http, IOptions<GoogleOAuthOptions> options) : IOAuthProviderService
{
    private readonly GoogleOAuthOptions _googleOAuthOptions = options.Value;

    public OAuthProvider Provider => OAuthProvider.Google;

    public async Task<OAuthUserInfo?> ExchangeCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        var tokenRequest = new Dictionary<string, string>
        {
            ["code"] = code,
            ["client_id"] = _googleOAuthOptions.ClientId,
            ["client_secret"] = _googleOAuthOptions.ClientSecret,
            ["redirect_uri"] = _googleOAuthOptions.DefaultRedirectUri,
            ["grant_type"] = "authorization_code"
        };

        var tokenResponse = await http.PostAsync("https://oauth2.googleapis.com/token", new FormUrlEncodedContent(tokenRequest), cancellationToken);

        tokenResponse.EnsureSuccessStatusCode();

        var tokenContent = await tokenResponse.Content.ReadFromJsonAsync<GoogleTokenResponse>(cancellationToken);

        var userInfoResponse = await http.GetAsync($"https://www.googleapis.com/oauth2/v2/userinfo?access_token={tokenContent!.AccessToken}", cancellationToken);

        userInfoResponse.EnsureSuccessStatusCode();

        var userInfoContent = await userInfoResponse.Content.ReadFromJsonAsync<GoogleUserInfoResponse>(cancellationToken);

        return new OAuthUserInfo(userInfoContent!.Email, userInfoContent.Name, userInfoContent.Picture);
    }
}
