using IdentityForge.Application.Email;
using IdentityForge.Application.Features.Auth;
using IdentityForge.Application.Features.Auth.MagicLink;
using IdentityForge.Application.Features.Auth.OAuth;
using IdentityForge.Application.Identity;
using IdentityForge.Domain.MagicLinkTokens;
using IdentityForge.Domain.Users;
using IdentityForge.Infrastructure.Data;
using IdentityForge.Infrastructure.Data.Repositories;
using IdentityForge.Infrastructure.Email;
using IdentityForge.Infrastructure.Identity;
using IdentityForge.Infrastructure.Identity.Jwt;
using IdentityForge.Infrastructure.Identity.MagicLink;
using IdentityForge.Infrastructure.Identity.OAuth;
using IdentityForge.Infrastructure.Identity.OAuth.GitHub;
using IdentityForge.Infrastructure.Identity.OAuth.Google;

namespace IdentityForge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>((sp, opts) =>
        {
            opts.UseNpgsql(configuration.GetConnectionString("DefaultConnection")).AddAsyncSeeding(sp);
        });

        services.AddScoped<AppDbContextInitialiser>();

        services
            .AddHealthChecks()
            .AddDbContextCheck<AppDbContext>("Database");

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

        services.AddAuthorization();

        services.AddHttpContextAccessor();

        services.AddHttpClient();

        services.AddScoped<IUserContext, UserContext>();

        services.AddSingleton<ITokenProvider, TokenProvider>();

        services
            .AddOptions<MagicLinkOptions>()
            .Bind(configuration.GetSection("MagicLink"))
            .ValidateOnStart();

        services.AddScoped<IMagicLinkProvider, MagicLinkProvider>();

        services
            .AddOptions<GoogleOAuthOptions>()
            .Bind(configuration.GetSection("OAuth:Google"))
            .ValidateOnStart();

        services.AddSingleton<IValidateOptions<GoogleOAuthOptions>, GoogleOAuthOptionsValidator>();

        services.AddHttpClient<GoogleOAuthProvider>(client =>
        {
            client.Timeout = TimeSpan.FromSeconds(10);
        });

        services.AddScoped<IOAuthProvider, GoogleOAuthProvider>();

        services
            .AddOptions<GitHubOAuthOptions>()
            .Bind(configuration.GetSection("OAuth:GitHub"))
            .ValidateOnStart();

        services.AddSingleton<IValidateOptions<GitHubOAuthOptions>, GitHubOAuthOptionsValidator>();

        services.AddHttpClient<GitHubOAuthProvider>(client =>
        {
            client.Timeout = TimeSpan.FromSeconds(10);
        });

        services.AddScoped<IOAuthProvider, GitHubOAuthProvider>();

        services.AddScoped<IOAuthProviderFactory, OAuthProviderFactory>();

        services
            .AddOptions<MailServerOptions>()
            .Bind(configuration.GetSection("MailServer"))
            .ValidateOnStart();

        services.AddSingleton<IEmailSender, SmtpEmailSender>();

        services.AddTransient<IUserRepository, UserRepository>();

        services.AddTransient<IMagicLinkTokenRepository, MagicLinkTokenRepository>();

        return services;
    }
}
