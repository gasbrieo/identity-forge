namespace IdentityForge.Infrastructure.Identity.OAuth.GitHub;

public sealed record GitHubEmailResponse(string Email, bool Primary, bool Verified, string? Visibility);
