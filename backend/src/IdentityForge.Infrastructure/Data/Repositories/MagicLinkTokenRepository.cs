using IdentityForge.Domain.MagicLinkTokens;

namespace IdentityForge.Infrastructure.Data.Repositories;

public class MagicLinkTokenRepository(AppDbContext context) : IMagicLinkTokenRepository
{
    public Task<MagicLinkToken?> GetValidTokenAsync(string token, CancellationToken cancellationToken = default)
    {
        return context.MagicLinkTokens.FirstOrDefaultAsync(x => x.Token == token && !x.Used && x.ExpiresAt >= DateTime.UtcNow, cancellationToken);
    }

    public async Task AddAsync(MagicLinkToken token, CancellationToken cancellationToken = default)
    {
        await context.MagicLinkTokens.AddAsync(token, cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}
