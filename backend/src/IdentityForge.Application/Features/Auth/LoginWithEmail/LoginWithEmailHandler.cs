using IdentityForge.Application.Identity;
using IdentityForge.Application.Messaging;
using IdentityForge.Application.Results;

namespace IdentityForge.Application.Features.Auth.LoginWithEmail;

internal sealed class LoginWithEmailHandler(IIdentityService identityService, ITokenProvider tokenProvider) : ICommandHandler<LoginWithEmailCommand, AuthResponse>
{
    public async Task<Result<AuthResponse>> HandleAsync(LoginWithEmailCommand command, CancellationToken cancellationToken = default)
    {
        var user = await identityService.FindByEmailAsync(command.Email);

        if (user is null)
            return Result.Failure<AuthResponse>(AuthErrors.UserNotFound);

        if (await identityService.IsLockedOutAsync(user))
            return Result.Failure<AuthResponse>(AuthErrors.UserLockedOut);

        if (!await identityService.CheckPasswordAsync(user, command.Password))
        {
            await identityService.AccessFailedAsync(user);
            return Result.Failure<AuthResponse>(AuthErrors.InvalidCredentials);
        }

        await identityService.ResetAccessFailedCountAsync(user);

        var token = tokenProvider.Create(user);

        return new AuthResponse(user.Email!, user.Name, user.AvatarUrl, token);
    }
}
