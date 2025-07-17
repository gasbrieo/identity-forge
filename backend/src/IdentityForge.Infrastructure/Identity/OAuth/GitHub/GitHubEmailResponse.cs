namespace IdentityForge.Infrastructure.Identity.OAuth.GitHub;

public sealed class GitHubEmailResponse
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = default!;

    [JsonPropertyName("primary")]
    public bool Primary { get; set; }

    [JsonPropertyName("verified")]
    public bool Verified { get; set; }
};
