namespace IdentityForge.Domain.Users;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser()
    {
        LockoutEnabled = true;
    }
}
