namespace IdentityForge.Infrastructure.Identity.MagicLink;

public sealed class MagicLinkOptions
{
    public string DefaultRedirectUrl { get; set; } = default!;
    public int ExpirationMinutes { get; set; } = default!;
}

internal sealed class MagicLinkOptionsValidator : IValidateOptions<MagicLinkOptions>
{
    public ValidateOptionsResult Validate(string? name, MagicLinkOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.DefaultRedirectUrl))
            return ValidateOptionsResult.Fail("MagicLink DefaultRedirectUrl not configured");

        if (options.ExpirationMinutes <= 0)
            return ValidateOptionsResult.Fail("MagicLink ExpirationMinutes not configured");

        return ValidateOptionsResult.Success;
    }
}
