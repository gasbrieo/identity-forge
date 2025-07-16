using IdentityForge.Application.Results;

namespace IdentityForge.Infrastructure.Identity.Extensions;

internal static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(new ErrorList("Identity.General", [.. result.Errors.Select(e => Error.Problem(e.Code, e.Description))]));
    }
}
