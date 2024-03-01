using Microsoft.EntityFrameworkCore;

namespace API.Contexts.DependencyInjection;

public static class IdentityServerContextDependencyInjection
{
    public static IServiceCollection AddIdentityServerContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityServerContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("IdentityServerConnection"));
        });

        return services;
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
