using IdentityForge.Domain.Users;
using IdentityForge.Infrastructure.Identity;

namespace IdentityForge.Infrastructure.Data;

public class AppDbContextInitialiser(ILogger<AppDbContextInitialiser> logger, IOptions<AdminUserOptions> options, AppDbContext context)
{
    private readonly AdminUserOptions _adminUserOptions = options.Value;

    public async Task InitialiseAsync()
    {
        try
        {
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initialising the database");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        var administrator = new User(_adminUserOptions.Email, _adminUserOptions.Name, _adminUserOptions.AvatarUrl);

        if (await context.Users.AllAsync(x => x.Email != administrator.Email))
        {
            await context.Users.AddAsync(administrator);
            await context.SaveChangesAsync();
        }
    }
}
