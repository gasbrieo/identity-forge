using IdentityForge.Application.Identity;
using IdentityForge.Application.Results;
using IdentityForge.Domain.Users;
using IdentityForge.Infrastructure.Identity.Extensions;

namespace IdentityForge.Infrastructure.Identity;

internal sealed class IdentityService(UserManager<ApplicationUser> userManager) : IIdentityService
{
    public async Task<Result> CreateAsync(ApplicationUser user)
    {
        var result = await userManager.CreateAsync(user);
        return result.ToApplicationResult();
    }

    public async Task<Result> DeleteAsync(ApplicationUser user)
    {
        var result = await userManager.DeleteAsync(user);
        return result.ToApplicationResult();
    }

    public Task<ApplicationUser?> FindByIdAsync(Guid id)
    {
        return userManager.FindByIdAsync(id.ToString());
    }

    public Task<ApplicationUser?> FindByEmailAsync(string email)
    {
        return userManager.FindByEmailAsync(email);
    }

    public Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
    {
        return userManager.CheckPasswordAsync(user, password);
    }

    public Task AccessFailedAsync(ApplicationUser user)
    {
        return userManager.AccessFailedAsync(user);
    }

    public Task ResetAccessFailedCountAsync(ApplicationUser user)
    {
        return userManager.ResetAccessFailedCountAsync(user);
    }

    public async Task<Result> AddPasswordAsync(ApplicationUser user, string password)
    {
        var result = await userManager.AddPasswordAsync(user, password);
        return result.ToApplicationResult();
    }

    public async Task<Result> RemovePasswordAsync(ApplicationUser user)
    {
        var result = await userManager.RemovePasswordAsync(user);
        return result.ToApplicationResult();
    }

    public async Task<IEnumerable<string>> GetRolesAsync(ApplicationUser user)
    {
        return await userManager.GetRolesAsync(user);
    }

    public async Task<Result> AddToRolesAsync(ApplicationUser user, IEnumerable<string> roles)
    {
        var result = await userManager.AddToRolesAsync(user, roles);
        return result.ToApplicationResult();
    }

    public async Task<Result> RemoveFromRolesAsync(ApplicationUser user, IEnumerable<string> roles)
    {
        var result = await userManager.RemoveFromRolesAsync(user, roles);
        return result.ToApplicationResult();
    }

    public Task<bool> IsLockedOutAsync(ApplicationUser user)
    {
        return userManager.IsLockedOutAsync(user);
    }

    public async Task<Result> SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd)
    {
        var result = await userManager.SetLockoutEndDateAsync(user, lockoutEnd);
        return result.ToApplicationResult();
    }
}
