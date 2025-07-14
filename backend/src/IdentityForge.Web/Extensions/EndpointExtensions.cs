using IdentityForge.Infrastructure.Identity;
using IdentityForge.Web.Endpoints;

namespace IdentityForge.Web.Extensions;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        var endpoints = assembly
            .DefinedTypes
            .Where(t => t is { IsAbstract: false, IsInterface: false } && typeof(IEndpoint).IsAssignableFrom(t))
            .SelectMany(t =>
            {
                var interfaces = t.GetInterfaces()
                    .Where(i => typeof(IEndpoint).IsAssignableFrom(i) && i != typeof(IEndpoint));
                return interfaces.Select(i => ServiceDescriptor.Transient(i, t));
            });

        services.TryAddEnumerable(endpoints);

        return services;
    }

    public static IApplicationBuilder MapVersionedEndpoints<TVersionedEndpoint>(this WebApplication app, ApiVersion version) where TVersionedEndpoint : IEndpoint
    {
        var versionSet = app.NewApiVersionSet()
            .HasApiVersion(version)
            .ReportApiVersions()
            .Build();

        var group = app.MapGroup("api/v{version:apiVersion}")
            .WithApiVersionSet(versionSet)
            .HasApiVersion(version);

        var endpoints = app.Services.GetRequiredService<IEnumerable<TVersionedEndpoint>>();

        foreach (var endpoint in endpoints)
            endpoint.MapEndpoint(group);

        return app;
    }

    public static RouteHandlerBuilder HasPermission(this RouteHandlerBuilder app, PermissionDefinition permission)
    {
        return app.RequireAuthorization(permission.Name);
    }
}
