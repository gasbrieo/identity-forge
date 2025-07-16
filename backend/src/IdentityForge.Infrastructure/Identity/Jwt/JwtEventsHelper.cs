namespace IdentityForge.Infrastructure.Identity.Jwt;

public static class JwtEventsHelper
{
    public static JwtBearerEvents CreateDefault() => new()
    {
        OnChallenge = async context =>
        {
            context.HandleResponse();
            await WriteProblem(context.Response, StatusCodes.Status401Unauthorized,
                "Unauthorized", "You are not authenticated");
        },
        OnForbidden = async context =>
        {
            await WriteProblem(context.Response, StatusCodes.Status403Forbidden,
                "Forbidden", "You do not have permission to access this resource");
        }
    };

    private static Task WriteProblem(HttpResponse response, int status, string title, string detail)
    {
        response.StatusCode = status;
        response.ContentType = "application/problem+json";
        return response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = detail
        });
    }
}
