namespace IdentityForge.Infrastructure.Identity.OAuth.GitHub;

public sealed record GitHubTokenResponse(
    [property: JsonPropertyName("access_token")] string AccessToken
);
