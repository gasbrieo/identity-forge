namespace IdentityForge.Application.Features.Auth.MagicLink.VerifyMagicLink;

internal sealed class VerifyMagicLinkValidator : AbstractValidator<VerifyMagicLinkCommand>
{
    public VerifyMagicLinkValidator()
    {
        RuleFor(c => c.Token).NotEmpty();
    }
}
