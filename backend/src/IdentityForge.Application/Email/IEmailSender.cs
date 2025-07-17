namespace IdentityForge.Application.Email;

public interface IEmailSender
{
    Task SendAsync(string to, string subject, string textBody, string? htmlBody = null, CancellationToken cancellationToken = default);
}
