using IdentityForge.Application.Messaging;
using IdentityForge.Application.Results;
using IdentityForge.Domain.Users;

namespace IdentityForge.Application.Features.Auth.OAuth.ExchangeOAuthCode;

internal sealed class ExchangeOAuthCodeHandler(IOAuthProviderFactory providerFactory, IUserRepository userRepository, ITokenProvider tokenProvider) : ICommandHandler<ExchangeOAuthCodeCommand, AuthResponse>
{
    private readonly IOAuthProviderFactory _providerFactory = providerFactory;

    public async Task<Result<AuthResponse>> HandleAsync(ExchangeOAuthCodeCommand command, CancellationToken cancellationToken = default)
    {
        var provider = _providerFactory.GetProvider(command.Provider);

        var oAuthUserInfo = await provider.ExchangeCodeAsync(command.Code, cancellationToken);

        if (oAuthUserInfo is null)
            return Result.Failure<AuthResponse>(AuthErrors.OAuthFailed);

        var user = await userRepository.GetByEmailAsync(oAuthUserInfo.Email, cancellationToken);

        if (user is null)
        {
            user = new User(oAuthUserInfo.Email, oAuthUserInfo.Name, oAuthUserInfo.AvatarUrl);

            await userRepository.AddAsync(user, cancellationToken);

            await userRepository.SaveChangesAsync(cancellationToken);
        }

        var token = tokenProvider.CreateAccessToken(user);

        return new AuthResponse(user.Email, user.Name, user.AvatarUrl, token);
    }
}
