using IdentityForge.Application.Features.Auth;
using IdentityForge.Application.Features.Auth.MagicLink.VerifyMagicLink;
using IdentityForge.Application.Messaging;
using IdentityForge.Web.Extensions;
using IdentityForge.Web.Infrastructure;

namespace IdentityForge.Web.Endpoints.V1.Auth.MagicLink;

internal sealed class VerifyMagicLinkEndpoint : IApiV1Endpoint
{
    public const string Route = "api/v1/auth/magic-link/verify";

    public record Request(string Token);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/magic-link/verify", async (
            Request request,
            ICommandHandler<VerifyMagicLinkCommand, AuthResponse> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new VerifyMagicLinkCommand(request.Token);

            var result = await handler.HandleAsync(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Auth);
    }
}
