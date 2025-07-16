using IdentityForge.Application.Features.Auth;
using IdentityForge.Application.Features.Auth.ExchangeOAuthCode;
using IdentityForge.Application.Identity.OAuth;
using IdentityForge.Application.Messaging;
using IdentityForge.Web.Extensions;
using IdentityForge.Web.Infrastructure;

namespace IdentityForge.Web.Endpoints.V1.Auth;

internal sealed class ExchangeOAuthCodeEndpoint : IApiV1Endpoint
{
    public const string Route = "api/v1/auth/oauth/exchange";

    public record Request(OAuthProvider Provider, string Code);

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("auth/oauth/exchange", async (
            Request request,
            ICommandHandler<ExchangeOAuthCodeCommand, AuthResponse> handler,
            CancellationToken cancellationToken) =>
        {
            var command = new ExchangeOAuthCodeCommand(
                request.Provider,
                request.Code);

            var result = await handler.HandleAsync(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Auth);
    }
}
