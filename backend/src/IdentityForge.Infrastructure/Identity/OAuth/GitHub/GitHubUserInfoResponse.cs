namespace IdentityForge.Infrastructure.Identity.OAuth.GitHub;

public sealed record GitHubUserInfoResponse(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("avatar_url")] string AvatarUrl);
