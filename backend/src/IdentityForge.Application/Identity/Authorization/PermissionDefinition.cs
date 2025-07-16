namespace IdentityForge.Application.Identity.Authorization;

public sealed class PermissionDefinition(string name, params string[] roles)
{
    public string Name { get; } = name;
    public IReadOnlyList<string> Roles { get; } = roles;
}
