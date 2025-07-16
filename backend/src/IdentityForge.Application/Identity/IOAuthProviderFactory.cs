using IdentityForge.Application.Identity.OAuth;

namespace IdentityForge.Application.Identity;

public interface IOAuthProviderFactory
{
    IOAuthProviderService GetProvider(OAuthProvider provider);
}

