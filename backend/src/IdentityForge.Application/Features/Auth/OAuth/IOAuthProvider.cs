namespace IdentityForge.Application.Features.Auth.OAuth;

public interface IOAuthProvider
{
    OAuthProvider Provider { get; }

    Task<OAuthUserInfo?> ExchangeCodeAsync(string code, CancellationToken cancellationToken = default);
}

