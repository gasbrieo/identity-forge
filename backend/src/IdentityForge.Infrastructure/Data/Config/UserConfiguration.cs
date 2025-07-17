using IdentityForge.Domain.Users;

namespace IdentityForge.Infrastructure.Data.Config;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.AvatarUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasIndex(x => x.Email).IsUnique();
    }
}
