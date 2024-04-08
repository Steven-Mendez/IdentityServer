using IdentityServer.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.DatabaseContexts;

public class IdentityServerContext(DbContextOptions<IdentityServerContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityServerContext).Assembly);
    }
}