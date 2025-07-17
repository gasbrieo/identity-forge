using IdentityForge.Application.Email;

namespace IdentityForge.Infrastructure.Email;

internal class SmtpEmailSender(IOptions<MailServerOptions> options, ILogger<SmtpEmailSender> logger) : IEmailSender
{
    private readonly MailServerOptions _mailServerOptions = options.Value;

    public async Task SendAsync(string to, string subject, string textBody, string? htmlBody = null, CancellationToken cancellationToken = default)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress(
            _mailServerOptions.DefaultFromName,
            _mailServerOptions.DefaultFromAddress));

        message.To.Add(MailboxAddress.Parse(to));

        message.Subject = subject;

        var bodyBuilder = new BodyBuilder
        {
            TextBody = textBody,
            HtmlBody = htmlBody ?? $"<p>{textBody}</p>"
        };

        message.Body = bodyBuilder.ToMessageBody();

        using var client = new SmtpClient();

        await client.ConnectAsync(_mailServerOptions.Hostname, _mailServerOptions.Port, SecureSocketOptions.StartTls, cancellationToken);

        await client.AuthenticateAsync(_mailServerOptions.Username, _mailServerOptions.Password, cancellationToken);

        await client.SendAsync(message, cancellationToken);
        await client.DisconnectAsync(true, cancellationToken);

        logger.LogWarning("Sending email to {to} from {from} with subject {subject} using {type}.", to, _mailServerOptions.DefaultFromAddress, subject, nameof(SmtpEmailSender));
    }
}
