namespace IdentityForge.Infrastructure.Identity;

public sealed class PermissionDefinition(string name, params string[] roles)
{
    public string Name { get; } = name;
    public IReadOnlyList<string> Roles { get; } = roles;
}
