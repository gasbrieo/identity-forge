namespace IdentityForge.Web.Extensions;

public static class CorsExtensions
{
    private const string DefaultPolicyName = "DefaultCorsPolicy";

    public static IServiceCollection AddDefaultCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(DefaultPolicyName, policy =>
            {
                policy
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("WWW-Authenticate");
            });
        });

        return services;
    }

    public static IApplicationBuilder UseDefaultCors(this IApplicationBuilder app)
    {
        app.UseCors(DefaultPolicyName);

        return app;
    }
}
