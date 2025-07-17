namespace IdentityForge.Application.Features.Auth.MagicLink.SendMagicLink;

internal sealed class SendMagicLinkValidator : AbstractValidator<SendMagicLinkCommand>
{
    public SendMagicLinkValidator()
    {
        RuleFor(c => c.Email).NotEmpty();
    }
}
