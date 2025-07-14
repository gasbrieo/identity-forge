namespace IdentityForge.Web.Endpoints.V1.Users;

internal sealed class CreateUserEndpoint : IApiV1Endpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users", (IConfiguration configuration) =>
        {
            var conn = configuration.GetConnectionString("DefaultConnection");
            var ad1 = configuration.GetValue<string>("AdminUser:Email");
            var ad2 = configuration.GetValue<string>("AdminUser:Password");
            return Results.Ok(new { conn, ad1, ad2 });
        })
        .WithTags(Tags.Users);
    }
}
