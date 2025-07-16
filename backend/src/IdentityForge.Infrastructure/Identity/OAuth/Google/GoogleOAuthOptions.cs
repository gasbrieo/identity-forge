namespace IdentityForge.Infrastructure.Identity.OAuth.Google;

public sealed class GoogleOAuthOptions
{
    public string ClientId { get; set; } = default!;
    public string ClientSecret { get; set; } = default!;
    public string DefaultRedirectUri { get; set; } = default!;
}

internal sealed class GoogleOAuthOptionsValidator : IValidateOptions<GoogleOAuthOptions>
{
    public ValidateOptionsResult Validate(string? name, GoogleOAuthOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.ClientId))
            return ValidateOptionsResult.Fail("Google ClientId not configured");

        if (string.IsNullOrWhiteSpace(options.ClientSecret))
            return ValidateOptionsResult.Fail("Google ClientSecret not configured");

        if (string.IsNullOrWhiteSpace(options.DefaultRedirectUri))
            return ValidateOptionsResult.Fail("Google DefaultRedirectUri not configured");

        return ValidateOptionsResult.Success;
    }
}

