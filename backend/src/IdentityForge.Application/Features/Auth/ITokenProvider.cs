using IdentityForge.Domain.Users;

namespace IdentityForge.Application.Features.Auth;

public interface ITokenProvider
{
    string CreateAccessToken(User user);
}
