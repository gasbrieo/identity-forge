using IdentityForge.Application.Identity;
using IdentityForge.Domain.Users;
using IdentityForge.Infrastructure.Data;
using IdentityForge.Infrastructure.Identity;

namespace IdentityForge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDb(configuration)
            .AddHealth()
            .AddIdentity()
            .AddAdminUserOptions(configuration)
            .AddAuthenticationInternal(configuration)
            .AddAuthorizationInternal()
            .AddServices();
    }

    private static IServiceCollection AddDb(this IServiceCollection services, IConfiguration config)
    {
        var conn = config.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>((sp, opts) =>
        {
            opts.UseNpgsql(conn).AddAsyncSeeding(sp);
        });

        services.AddScoped<ApplicationDbContextInitialiser>();

        return services;
    }

    private static IServiceCollection AddHealth(this IServiceCollection services)
    {
        services
            .AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>("Database");

        return services;
    }

    private static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }

    private static IServiceCollection AddAdminUserOptions(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<AdminUserOptions>(options =>
        {
            var section = config.GetSection("AdminUser");
            if (!section.Exists())
                throw new InvalidOperationException("Section 'AdminUser' is missing");

            section.Bind(options);

            if (string.IsNullOrWhiteSpace(options.Email))
                throw new InvalidOperationException("Admin user email not configured");

            if (string.IsNullOrWhiteSpace(options.Password))
                throw new InvalidOperationException("Admin user password not configured");
        });

        return services;
    }

    private static IServiceCollection AddAuthenticationInternal(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication();

        services.AddHttpContextAccessor();

        services.AddScoped<IUserContext, UserContext>();

        services.AddSingleton<ITokenProvider, TokenProvider>();

        return services;
    }

    private static IServiceCollection AddAuthorizationInternal(this IServiceCollection services)
    {
        services.AddAuthorization();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IIdentityService, IdentityService>();

        return services;
    }
}
