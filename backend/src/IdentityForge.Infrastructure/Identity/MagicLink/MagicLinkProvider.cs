using IdentityForge.Application.Email;
using IdentityForge.Application.Features.Auth.MagicLink;
using IdentityForge.Domain.MagicLinkTokens;

namespace IdentityForge.Infrastructure.Identity.MagicLink;

public class MagicLinkProvider(IOptions<MagicLinkOptions> options, IEmailSender emailSender) : IMagicLinkProvider
{
    private readonly MagicLinkOptions _magicLinkOptions = options.Value;

    public int GetExpirationMinutes()
    {
        return _magicLinkOptions.ExpirationMinutes;
    }

    public async Task SendMagicLinkAsync(MagicLinkToken magicLinkToken, CancellationToken cancellationToken = default)
    {
        var link = $"{_magicLinkOptions.DefaultRedirectUrl}?token={magicLinkToken.Token}";

        var subject = "Your magic login link";

        var body = $"""
            Hello, 

            Click the link below to login:

            {link}

            This link will expire in {_magicLinkOptions.ExpirationMinutes} minutes.

            If you didn’t request this, just ignore this email.
        """;

        await emailSender.SendAsync(magicLinkToken.Email, subject, body, isHtml: false, cancellationToken);
    }
}
