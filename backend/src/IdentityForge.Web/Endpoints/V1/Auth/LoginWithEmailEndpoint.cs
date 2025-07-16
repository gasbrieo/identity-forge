using IdentityForge.Application.Features.Auth;
using IdentityForge.Application.Features.Auth.LoginWithEmail;
using IdentityForge.Application.Messaging;
using IdentityForge.Web.Extensions;
using IdentityForge.Web.Infrastructure;

namespace IdentityForge.Web.Endpoints.V1.Auth;

internal sealed class LoginWithEmailEndpoint : IApiV1Endpoint
{
    public const string Route = "api/v1/auth/login";

    public record Request(string Email, string Password);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/login", async (
            Request request,
            ICommandHandler<LoginWithEmailCommand, AuthResponse> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new LoginWithEmailCommand(
                request.Email,
                request.Password);

            var result = await handler.HandleAsync(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Auth);
    }
}
