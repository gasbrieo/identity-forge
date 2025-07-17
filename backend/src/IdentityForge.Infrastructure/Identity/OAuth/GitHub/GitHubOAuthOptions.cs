namespace IdentityForge.Infrastructure.Identity.OAuth.GitHub;

public sealed class GitHubOAuthOptions
{
    public string ClientId { get; set; } = default!;
    public string ClientSecret { get; set; } = default!;
    public string DefaultRedirectUrl { get; set; } = default!;
}

internal sealed class GitHubOAuthOptionsValidator : IValidateOptions<GitHubOAuthOptions>
{
    public ValidateOptionsResult Validate(string? name, GitHubOAuthOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.ClientId))
            return ValidateOptionsResult.Fail("GitHub ClientId not configured");

        if (string.IsNullOrWhiteSpace(options.ClientSecret))
            return ValidateOptionsResult.Fail("GitHub ClientSecret not configured");

        if (string.IsNullOrWhiteSpace(options.DefaultRedirectUrl))
            return ValidateOptionsResult.Fail("GitHub DefaultRedirectUrl not configured");

        return ValidateOptionsResult.Success;
    }
}
