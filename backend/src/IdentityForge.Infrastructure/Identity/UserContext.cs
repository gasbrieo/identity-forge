using IdentityForge.Application.Identity;
using IdentityForge.Infrastructure.Identity.Extensions;

namespace IdentityForge.Infrastructure.Identity;

internal sealed class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public Guid UserId =>
        httpContextAccessor
            .HttpContext?
            .User
            .GetUserId() ??
        throw new InvalidOperationException("User context is unavailable");
}
