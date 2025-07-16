using IdentityForge.Application.Identity;
using IdentityForge.Application.Identity.OAuth;

namespace IdentityForge.Infrastructure.Identity.OAuth;

internal sealed class OAuthProviderFactory(IEnumerable<IOAuthProviderService> providers) : IOAuthProviderFactory
{
    public IOAuthProviderService GetProvider(OAuthProvider provider)
        => providers.FirstOrDefault(x => x.Provider == provider)
           ?? throw new InvalidOperationException($"Provider '{provider}' not registered.");
}
