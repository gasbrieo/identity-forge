namespace IdentityForge.Web.Endpoints.V1.Users;

internal sealed class CreateUserEndpoint : IApiV1Endpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users", (IConfiguration configuration) =>
        {
            var conn = configuration.GetConnectionString("DefaultConnection");
            var email = configuration.GetValue<string>("AdminUser:Email");
            var password = configuration.GetValue<string>("AdminUser:Password");
            return Results.Ok(new { conn, email, password });
        })
        .WithTags(Tags.Users);
    }
}
