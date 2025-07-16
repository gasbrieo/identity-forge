namespace IdentityForge.Infrastructure.Options;

public sealed class AdminUserOptions
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}

internal sealed class AdminUserOptionsValidator : IValidateOptions<AdminUserOptions>
{
    public ValidateOptionsResult Validate(string? name, AdminUserOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.Email))
            return ValidateOptionsResult.Fail("Admin user email not configured");

        if (string.IsNullOrWhiteSpace(options.Password))
            return ValidateOptionsResult.Fail("Admin user password not configured");

        return ValidateOptionsResult.Success;
    }
}
