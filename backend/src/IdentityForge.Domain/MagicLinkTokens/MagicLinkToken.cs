namespace IdentityForge.Domain.MagicLinkTokens;

public sealed class MagicLinkToken(string token, string email, DateTime expiresAt)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Token { get; set; } = token;
    public string Email { get; set; } = email;
    public DateTime ExpiresAt { get; set; } = expiresAt;
    public bool Used { get; private set; }

    public bool IsValid => !Used && DateTime.UtcNow <= ExpiresAt;

    public void MarkAsUsed() => Used = true;
}
