namespace IdentityForge.Application.Email;

public interface IEmailSender
{
    Task SendAsync(string to, string subject, string body, bool isHtml = true, CancellationToken cancellationToken = default);
}
