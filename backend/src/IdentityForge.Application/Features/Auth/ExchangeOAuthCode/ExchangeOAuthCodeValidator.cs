namespace IdentityForge.Application.Features.Auth.ExchangeOAuthCode;

internal sealed class ExchangeOAuthCodeValidator : AbstractValidator<ExchangeOAuthCodeCommand>
{
    public ExchangeOAuthCodeValidator()
    {
        RuleFor(c => c.Provider).NotEmpty();
        RuleFor(c => c.Code).NotEmpty();
    }
}
