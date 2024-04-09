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

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataBase(configuration);
        services.AddUnitsOfWork();
        services.AddRepositories();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
    }

    private static void AddDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityServerContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("IdentityServerConnection"));
        });
    }

    private static void AddUnitsOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }

    public static void EnsureIdentityServerDatabaseMigrated(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<IdentityServerContext>();
        context.Database.EnsureCreated();
        context.Database.Migrate();
    }
}