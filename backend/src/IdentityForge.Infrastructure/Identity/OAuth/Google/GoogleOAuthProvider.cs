using IdentityForge.Application.Features.Auth.OAuth;

namespace IdentityForge.Infrastructure.Identity.OAuth.Google;

internal sealed class GoogleOAuthProvider(HttpClient http, IOptions<GoogleOAuthOptions> options) : IOAuthProvider
{
    private readonly GoogleOAuthOptions _googleOAuthOptions = options.Value;

    public OAuthProvider Provider => OAuthProvider.Google;

    public async Task<OAuthUserInfo?> ExchangeCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        var accessToken = await RequestAccessTokenAsync(code, cancellationToken);

        if (string.IsNullOrWhiteSpace(accessToken)) return null;

        var userInfo = await GetUserInfoAsync(accessToken, cancellationToken);

        if (userInfo is null) return null;

        return new OAuthUserInfo(userInfo.Email, userInfo.Name, userInfo.Picture);
    }

    private async Task<string?> RequestAccessTokenAsync(string code, CancellationToken cancellationToken)
    {
        var tokenRequest = new Dictionary<string, string>
        {
            ["client_id"] = _googleOAuthOptions.ClientId,
            ["client_secret"] = _googleOAuthOptions.ClientSecret,
            ["code"] = code,
            ["grant_type"] = "authorization_code",
            ["redirect_uri"] = _googleOAuthOptions.DefaultRedirectUrl
        };

        using var response = await http.PostAsync(
            "https://oauth2.googleapis.com/token",
            new FormUrlEncodedContent(tokenRequest),
            cancellationToken
        );

        response.EnsureSuccessStatusCode();

        var tokenData = await response.Content.ReadFromJsonAsync<GoogleTokenResponse>(cancellationToken);
        return tokenData?.AccessToken;
    }

    private async Task<GoogleUserInfoResponse?> GetUserInfoAsync(string accessToken, CancellationToken cancellationToken)
    {
        var url = $"https://www.googleapis.com/oauth2/v2/userinfo?access_token={accessToken}";
        using var response = await http.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<GoogleUserInfoResponse>(cancellationToken);
    }
}
