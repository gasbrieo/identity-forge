using IdentityForge.Domain.MagicLinkTokens;

namespace IdentityForge.Application.Features.Auth.MagicLink;

public interface IMagicLinkProvider
{
    int GetExpirationMinutes();

    Task SendMagicLinkAsync(MagicLinkToken magicLinkToken, CancellationToken cancellationToken = default);
}
