namespace IdentityForge.Application.Features.Auth.OAuth;

public interface IOAuthProviderFactory
{
    IOAuthProvider GetProvider(OAuthProvider provider);
}

