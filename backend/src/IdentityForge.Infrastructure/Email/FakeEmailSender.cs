using IdentityForge.Application.Email;

namespace IdentityForge.Infrastructure.Email;

internal class FakeEmailSender(ILogger<FakeEmailSender> logger) : IEmailSender
{
    public Task SendAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(
            "Not actually sending an email to {to} with subject {subject} and body {body}",
            to,
            subject,
            body
        );

        return Task.CompletedTask;
    }

    public Task SendAsync(string to, string subject, string textBody, string? htmlBody = null, CancellationToken cancellationToken = default)
    {
        logger.LogInformation(
            "Not actually sending an email to {to} with subject {subject} and body {body}",
            to,
            subject,
            textBody
        );

        return Task.CompletedTask;
    }
}
