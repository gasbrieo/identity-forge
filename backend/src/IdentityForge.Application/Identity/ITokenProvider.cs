using IdentityForge.Domain.Users;

namespace IdentityForge.Application.Identity;

public interface ITokenProvider
{
    string Create(ApplicationUser user);
}
