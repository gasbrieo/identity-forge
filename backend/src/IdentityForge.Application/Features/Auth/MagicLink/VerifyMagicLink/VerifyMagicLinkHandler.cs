using IdentityForge.Application.Messaging;
using IdentityForge.Application.Results;
using IdentityForge.Domain.MagicLinkTokens;
using IdentityForge.Domain.Users;

namespace IdentityForge.Application.Features.Auth.MagicLink.VerifyMagicLink;

internal sealed class VerifyMagicLinkHandler(IMagicLinkTokenRepository magicLinkTokenRepository, IUserRepository userRepository, ITokenProvider tokenProvider) : ICommandHandler<VerifyMagicLinkCommand, AuthResponse>
{
    public async Task<Result<AuthResponse>> HandleAsync(VerifyMagicLinkCommand command, CancellationToken cancellationToken = default)
    {
        var magicToken = await magicLinkTokenRepository.GetValidTokenAsync(command.Token, cancellationToken);

        if (magicToken is null)
            return Result.Failure<AuthResponse>(AuthErrors.MagicLinkFailed);

        magicToken.MarkAsUsed();

        await magicLinkTokenRepository.SaveChangesAsync(cancellationToken);

        var user = await userRepository.GetByEmailAsync(magicToken.Email, cancellationToken);

        if (user is null)
        {
            var defaultName = magicToken.Email.Split('@')[0];
            var defaultAvatar = $"https://ui-avatars.com/api/?name={Uri.EscapeDataString(defaultName)}&background=random&color=fff";

            user = new User(magicToken.Email, defaultName, defaultAvatar);

            await userRepository.AddAsync(user, cancellationToken);

            await userRepository.SaveChangesAsync(cancellationToken);
        }

        var token = tokenProvider.CreateAccessToken(user);

        return new AuthResponse(user.Email, user.Name, user.AvatarUrl, token);
    }
}
