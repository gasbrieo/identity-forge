namespace IdentityForge.Web.Endpoints.V1.Users;

internal sealed class CreateUserEndpoint : IApiV1Endpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users", (IConfiguration configuration) =>
        {
            var conn = configuration.GetConnectionString("DefaultConnection");
            return Results.Ok(conn);
        })
        .WithTags(Tags.Users);
    }
}
