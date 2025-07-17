namespace IdentityForge.Domain.Users;

public sealed class User(string email, string name, string avatarUrl)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = email;
    public string Name { get; set; } = name;
    public string AvatarUrl { get; set; } = avatarUrl;
}
