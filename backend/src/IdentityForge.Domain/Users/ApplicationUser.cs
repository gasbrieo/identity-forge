namespace IdentityForge.Domain.Users;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }

    public ApplicationUser()
    {
        LockoutEnabled = true;
    }
}
