namespace IdentityForge.Infrastructure.Email;

public sealed class MailServerOptions
{
    public string Hostname { get; set; } = default!;
    public int Port { get; set; }
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public bool UseSsl { get; set; } = true;
    public string DefaultFromAddress { get; set; } = default!;
    public string DefaultFromName { get; set; } = default!;
}

internal sealed class MailServerOptionsValidator : IValidateOptions<MailServerOptions>
{
    public ValidateOptionsResult Validate(string? name, MailServerOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.Hostname))
            return ValidateOptionsResult.Fail("MailServer Hostname not configured");

        if (options.Port <= 0)
            return ValidateOptionsResult.Fail("MailServer Port not configured");

        if (string.IsNullOrWhiteSpace(options.Username))
            return ValidateOptionsResult.Fail("MailServer Username not configured");

        if (string.IsNullOrWhiteSpace(options.Password))
            return ValidateOptionsResult.Fail("MailServer Password not configured");

        if (string.IsNullOrWhiteSpace(options.DefaultFromAddress))
            return ValidateOptionsResult.Fail("MailServer DefaultFromAddress not configured");

        if (string.IsNullOrWhiteSpace(options.DefaultFromName))
            return ValidateOptionsResult.Fail("MailServer DefaultFromName not configured");

        return ValidateOptionsResult.Success;
    }
}
