namespace IdentityForge.Infrastructure.Identity;

public sealed class AdminUserOptions
{
    public string Email { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string AvatarUrl { get; set; } = default!;
}

internal sealed class AdminUserOptionsValidator : IValidateOptions<AdminUserOptions>
{
    public ValidateOptionsResult Validate(string? name, AdminUserOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.Email))
            return ValidateOptionsResult.Fail("AdminUser Email not configured");

        if (string.IsNullOrWhiteSpace(options.Name))
            return ValidateOptionsResult.Fail("AdminUser Name not configured");

        if (string.IsNullOrWhiteSpace(options.AvatarUrl))
            return ValidateOptionsResult.Fail("AdminUser AvatarUrl not configured");

        return ValidateOptionsResult.Success;
    }
}
