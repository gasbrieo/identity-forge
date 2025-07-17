using IdentityForge.Application.Messaging;
using IdentityForge.Application.Results;
using IdentityForge.Domain.MagicLinkTokens;

namespace IdentityForge.Application.Features.Auth.MagicLink.SendMagicLink;

internal sealed class SendMagicLinkHandler(IMagicLinkTokenRepository magicLinkTokenRepository, IMagicLinkProvider magicLinkProvider) : ICommandHandler<SendMagicLinkCommand>
{
    public async Task<Result> HandleAsync(SendMagicLinkCommand command, CancellationToken cancellationToken = default)
    {
        var expiresMinutes = magicLinkProvider.GetExpirationMinutes();

        var token = Guid.NewGuid().ToString();
        var expiresAt = DateTime.UtcNow.AddMinutes(expiresMinutes);

        var magicLinkToken = new MagicLinkToken(token, command.Email, expiresAt);

        await magicLinkTokenRepository.AddAsync(magicLinkToken, cancellationToken);
        await magicLinkTokenRepository.SaveChangesAsync(cancellationToken);

        await magicLinkProvider.SendMagicLinkAsync(magicLinkToken, cancellationToken);

        return Result.Success();
    }
}

