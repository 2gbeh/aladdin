using Microsoft.EntityFrameworkCore;
using server.Infrastructure.Persistence;

namespace server.Shared.Extensions;

/// <summary>
/// Extension methods for configuring persistence layer services
/// </summary>
public static class PersistenceExtensions
{
    /// <summary>
    /// Adds Entity Framework DbContext with MySQL configuration
    /// </summary>
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
            }

            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mySqlOptions =>
            {
                mySqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
            });
        });

        return services;
    }
}
