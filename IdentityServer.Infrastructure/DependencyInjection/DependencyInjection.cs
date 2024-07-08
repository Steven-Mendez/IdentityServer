using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Interfaces;
using IdentityServer.Infrastructure.Cryptography;
using IdentityServer.Infrastructure.DatabaseContexts;
using IdentityServer.Infrastructure.UnitsOfWork;
using IdentityServer.Infrastructure.Users.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Infrastructure.DependencyInjection;

/// <summary>
///     Provides extension methods for configuring the dependency injection container with services specific to the
///     IdentityServer infrastructure layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    ///     Adds infrastructure services to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="configuration">The application configuration where database connection strings are defined.</param>
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataBase(configuration);
        services.AddUnitsOfWork();
        services.AddRepositories();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
    }

    /// <summary>
    ///     Configures the database context for use with Entity Framework Core, using SQL Server as the database provider.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the database context to.</param>
    /// <param name="configuration">The application configuration where the database connection string is defined.</param>
    private static void AddDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityServerContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("IdentityServerConnection"));
        });
    }

    /// <summary>
    ///     Registers the unit of work pattern implementation for managing database transactions.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the unit of work to.</param>
    private static void AddUnitsOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    /// <summary>
    ///     Registers repository services for accessing domain entities.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the repositories to.</param>
    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }

    /// <summary>
    ///     Ensures that the IdentityServer database is created and migrates to the latest version on application startup.
    /// </summary>
    /// <param name="serviceProvider">The <see cref="IServiceProvider" /> to get the database context from.</param>
    public static void EnsureIdentityServerDatabaseMigrated(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<IdentityServerContext>();
        context.Database.Migrate();
    }
}