namespace IdentityForge.Infrastructure.Identity.OAuth.Google;

public sealed class GoogleOAuthOptions
{
    public string ClientId { get; set; } = default!;
    public string ClientSecret { get; set; } = default!;
    public string DefaultRedirectUrl { get; set; } = default!;
}

internal sealed class GoogleOAuthOptionsValidator : IValidateOptions<GoogleOAuthOptions>
{
    public ValidateOptionsResult Validate(string? name, GoogleOAuthOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.ClientId))
            return ValidateOptionsResult.Fail("Google ClientId not configured");

        if (string.IsNullOrWhiteSpace(options.ClientSecret))
            return ValidateOptionsResult.Fail("Google ClientSecret not configured");

        if (string.IsNullOrWhiteSpace(options.DefaultRedirectUrl))
            return ValidateOptionsResult.Fail("Google DefaultRedirectUrl not configured");

        return ValidateOptionsResult.Success;
    }
}

