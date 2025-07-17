using IdentityForge.Domain.MagicLinkTokens;

namespace IdentityForge.Infrastructure.Data.Config;

public class MagicLinkTokenConfiguration : IEntityTypeConfiguration<MagicLinkToken>
{
    public void Configure(EntityTypeBuilder<MagicLinkToken> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Token)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.ExpiresAt)
            .IsRequired();

        builder.Property(x => x.Used)
            .IsRequired();

        builder.HasIndex(x => x.Token).IsUnique();
    }
}
