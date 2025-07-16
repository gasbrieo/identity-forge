namespace IdentityForge.Domain.Users;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public string? Name { get; set; }
    public string? AvatarUri { get; set; }

    public ApplicationUser()
    {
        LockoutEnabled = true;
    }
}
