namespace IdentityForge.Infrastructure.Identity.OAuth.GitHub;

public sealed class GitHubUserInfoResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;

    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; set; } = default!;
};
