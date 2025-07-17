using IdentityForge.Application.Features.Auth.MagicLink.SendMagicLink;
using IdentityForge.Application.Messaging;
using IdentityForge.Web.Extensions;
using IdentityForge.Web.Infrastructure;

namespace IdentityForge.Web.Endpoints.V1.Auth.MagicLink;

internal sealed class SendMagicLinkEndpoint : IApiV1Endpoint
{
    public const string Route = "api/v1/auth/magic-link/send";

    public record Request(string Email);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/magic-link/send", async (
            Request request,
            ICommandHandler<SendMagicLinkCommand> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new SendMagicLinkCommand(request.Email);

            var result = await handler.HandleAsync(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Auth);
    }
}
