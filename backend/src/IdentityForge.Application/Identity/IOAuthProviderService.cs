using IdentityForge.Application.Identity.OAuth;

namespace IdentityForge.Application.Identity;

public interface IOAuthProviderService
{
    OAuthProvider Provider { get; }

    Task<OAuthUserInfo?> ExchangeCodeAsync(string code, CancellationToken cancellationToken = default);
}

