namespace IdentityForge.Infrastructure.Identity.OAuth.Google;

public sealed record GoogleTokenResponse(
    [property: JsonPropertyName("access_token")] string AccessToken
);
