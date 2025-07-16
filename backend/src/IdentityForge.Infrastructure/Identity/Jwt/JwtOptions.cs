namespace IdentityForge.Infrastructure.Identity.Jwt;

public sealed class JwtOptions
{
    public string Secret { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public int ExpirationMinutes { get; set; } = default!;
}

internal sealed class JwtOptionsValidator : IValidateOptions<JwtOptions>
{
    public ValidateOptionsResult Validate(string? name, JwtOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.Secret))
            return ValidateOptionsResult.Fail("JWT Secret not configured");

        if (string.IsNullOrWhiteSpace(options.Issuer))
            return ValidateOptionsResult.Fail("JWT Issuer not configured");

        if (string.IsNullOrWhiteSpace(options.Audience))
            return ValidateOptionsResult.Fail("JWT Audience not configured");

        if (options.ExpirationMinutes <= 0)
            return ValidateOptionsResult.Fail("JWT expiration must be greater than zero");

        return ValidateOptionsResult.Success;
    }
}
