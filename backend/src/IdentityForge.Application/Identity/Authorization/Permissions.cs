namespace IdentityForge.Application.Identity.Authorization;

public static class Permissions
{
    public static readonly PermissionDefinition CanListUsers =
        new("CanListUsers", Roles.Administrator);

    public static IEnumerable<PermissionDefinition> All
    {
        get
        {
            yield return CanListUsers;
        }
    }
}
