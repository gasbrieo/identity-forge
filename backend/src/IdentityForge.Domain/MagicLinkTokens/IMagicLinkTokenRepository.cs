namespace IdentityForge.Domain.MagicLinkTokens;

public interface IMagicLinkTokenRepository
{
    Task<MagicLinkToken?> GetValidTokenAsync(string token, CancellationToken cancellationToken = default);
    Task AddAsync(MagicLinkToken token, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
