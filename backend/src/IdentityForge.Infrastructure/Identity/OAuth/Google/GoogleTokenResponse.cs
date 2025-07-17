namespace IdentityForge.Infrastructure.Identity.OAuth.Google;

public sealed class GoogleTokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = default!;
};
