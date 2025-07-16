using IdentityForge.Application.Identity;
using IdentityForge.Application.Messaging;
using IdentityForge.Application.Results;
using IdentityForge.Domain.Users;

namespace IdentityForge.Application.Features.Auth.ExchangeOAuthCode;

internal sealed class ExchangeOAuthCodeHandler(IOAuthProviderFactory providerFactory, IIdentityService identityService, ITokenProvider tokenProvider) : ICommandHandler<ExchangeOAuthCodeCommand, AuthResponse>
{
    private readonly IOAuthProviderFactory _providerFactory = providerFactory;

    public async Task<Result<AuthResponse>> HandleAsync(ExchangeOAuthCodeCommand command, CancellationToken cancellationToken = default)
    {
        var provider = _providerFactory.GetProvider(command.Provider);

        var oAuthUserInfo = await provider.ExchangeCodeAsync(command.Code, cancellationToken);

        if (oAuthUserInfo is null)
            return Result.Failure<AuthResponse>(AuthErrors.OAuthFailed);

        var user = await identityService.FindByEmailAsync(oAuthUserInfo.Email);

        if (user is null)
        {
            user = new ApplicationUser
            {
                Email = oAuthUserInfo.Email,
                UserName = oAuthUserInfo.Email,
                AvatarUri = oAuthUserInfo.AvatarUri,
                Name = oAuthUserInfo.Name,
                EmailConfirmed = true,
            };

            var result = await identityService.CreateAsync(user);

            if (!result.IsSuccess)
                return Result.Failure<AuthResponse>(result.Error);
        }

        if (await identityService.IsLockedOutAsync(user))
            return Result.Failure<AuthResponse>(AuthErrors.UserLockedOut);

        await identityService.ResetAccessFailedCountAsync(user);

        var token = tokenProvider.Create(user);

        return new AuthResponse(user.Email!, user.Name, user.AvatarUri, token);
    }
}
