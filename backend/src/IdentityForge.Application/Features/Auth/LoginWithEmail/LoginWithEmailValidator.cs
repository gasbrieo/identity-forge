namespace IdentityForge.Application.Features.Auth.LoginWithEmail;

internal sealed class LoginWithEmailValidator : AbstractValidator<LoginWithEmailCommand>
{
    public LoginWithEmailValidator()
    {
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Password).NotEmpty();
    }
}
