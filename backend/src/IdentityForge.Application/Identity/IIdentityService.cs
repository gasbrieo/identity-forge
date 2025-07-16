using IdentityForge.Application.Results;
using IdentityForge.Domain.Users;

namespace IdentityForge.Application.Identity;

public interface IIdentityService
{
    Task<Result> CreateAsync(ApplicationUser user);
    Task<Result> DeleteAsync(ApplicationUser user);

    Task<ApplicationUser?> FindByIdAsync(Guid id);
    Task<ApplicationUser?> FindByEmailAsync(string email);

    Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    Task AccessFailedAsync(ApplicationUser user);
    Task ResetAccessFailedCountAsync(ApplicationUser user);

    Task<Result> AddPasswordAsync(ApplicationUser user, string password);
    Task<Result> RemovePasswordAsync(ApplicationUser user);

    Task<IEnumerable<string>> GetRolesAsync(ApplicationUser user);
    Task<Result> AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles);
    Task<Result> RemoveFromRolesAsync(ApplicationUser user, IEnumerable<string> roles);

    Task<bool> IsLockedOutAsync(ApplicationUser user);
    Task<Result> SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd);
}
