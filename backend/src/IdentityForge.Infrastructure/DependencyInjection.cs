using IdentityForge.Application.Identity;
using IdentityForge.Application.Identity.Authorization;
using IdentityForge.Domain.Users;
using IdentityForge.Infrastructure.Data;
using IdentityForge.Infrastructure.Identity;
using IdentityForge.Infrastructure.Identity.Jwt;
using IdentityForge.Infrastructure.Identity.OAuth;
using IdentityForge.Infrastructure.Identity.OAuth.GitHub;
using IdentityForge.Infrastructure.Identity.OAuth.Google;
using IdentityForge.Infrastructure.Options;

namespace IdentityForge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>((sp, opts) =>
        {
            opts.UseNpgsql(configuration.GetConnectionString("DefaultConnection")).AddAsyncSeeding(sp);
        });

        services.AddScoped<ApplicationDbContextInitialiser>();

        services
            .AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>("Database");

        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services
            .AddOptions<AdminUserOptions>()
            .Bind(configuration.GetSection("AdminUser"))
            .ValidateOnStart();

        services.AddSingleton<IValidateOptions<AdminUserOptions>, AdminUserOptionsValidator>();

        services
            .AddOptions<JwtOptions>()
            .Bind(configuration.GetSection("Jwt"))
            .ValidateOnStart();

        services.AddSingleton<IValidateOptions<JwtOptions>, JwtOptionsValidator>();

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var jwt = configuration.GetSection("Jwt").Get<JwtOptions>()!;

                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Secret)),
                    ValidIssuer = jwt.Issuer,
                    ValidAudience = jwt.Audience,
                    ClockSkew = TimeSpan.Zero
                };
            });

        services.AddAuthorization(options =>
        {
            foreach (var permission in Permissions.All)
            {
                options.AddPolicy(permission.Name, policy =>
                    policy.RequireRole(permission.Roles));
            }
        });

        services.AddHttpContextAccessor();

        services.AddHttpClient();

        services.AddScoped<IUserContext, UserContext>();

        services.AddSingleton<ITokenProvider, TokenProvider>();

        services
            .AddOptions<GoogleOAuthOptions>()
            .Bind(configuration.GetSection("OAuth:Google"))
            .ValidateOnStart();

        services.AddSingleton<IValidateOptions<GoogleOAuthOptions>, GoogleOAuthOptionsValidator>();

        services.AddHttpClient<GoogleOAuthProviderService>(client =>
        {
            client.Timeout = TimeSpan.FromSeconds(10);
        });

        services.AddScoped<IOAuthProviderService, GoogleOAuthProviderService>();

        services
            .AddOptions<GitHubOAuthOptions>()
            .Bind(configuration.GetSection("OAuth:GitHub"))
            .ValidateOnStart();

        services.AddSingleton<IValidateOptions<GitHubOAuthOptions>, GitHubOAuthOptionsValidator>();

        services.AddHttpClient<GitHubOAuthProviderService>(client =>
        {
            client.Timeout = TimeSpan.FromSeconds(10);
        });

        services.AddScoped<IOAuthProviderService, GitHubOAuthProviderService>();

        services.AddScoped<IOAuthProviderFactory, OAuthProviderFactory>();

        services.AddTransient<IIdentityService, IdentityService>();

        return services;
    }
}
