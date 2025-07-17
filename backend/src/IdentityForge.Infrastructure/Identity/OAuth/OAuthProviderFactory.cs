using IdentityForge.Application.Features.Auth.OAuth;

namespace IdentityForge.Infrastructure.Identity.OAuth;

internal sealed class OAuthProviderFactory(IEnumerable<IOAuthProvider> providers) : IOAuthProviderFactory
{
    public IOAuthProvider GetProvider(OAuthProvider provider)
        => providers.FirstOrDefault(x => x.Provider == provider)
           ?? throw new InvalidOperationException($"Provider '{provider}' not registered.");
}
