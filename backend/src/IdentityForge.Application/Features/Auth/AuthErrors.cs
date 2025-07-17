using IdentityForge.Application.Results;

namespace IdentityForge.Application.Features.Auth;

public static class AuthErrors
{
    public static readonly Error UserNotFound = Error.NotFound(
        "Auth.UserNotFound",
        "No user was found with the provided credentials."
    );

    public static readonly Error UserLockedOut = Error.Conflict(
        "Auth.UserLockedOut",
        "The user account is locked due to multiple failed login attempts."
    );

    public static readonly Error InvalidCredentials = Error.Failure(
        "Auth.InvalidCredentials",
        "The provided credentials are invalid."
    );

    public static readonly Error AccessDenied = Error.Problem(
        "Auth.AccessDenied",
        "You do not have permission to perform this action."
    );

    public static readonly Error OAuthFailed = Error.Problem(
        "Auth.OAuthFailed",
        "Failed to exchange OAuth code."
    );

    public static readonly Error MagicLinkFailed = Error.Problem(
        "Auth.MagicLinkFailed",
        "Failed to verify Magic Link token."
    );
}
