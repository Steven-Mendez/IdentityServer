using IdentityServer.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.Infrastructure.DatabaseContexts;

/// <summary>
///     Represents the database context for Identity Server, configuring and managing database entities.
/// </summary>
/// <param name="options">The options to be used by the DbContext.</param>
public class IdentityServerContext(DbContextOptions<IdentityServerContext> options) : DbContext(options)
{
    /// <summary>
    ///     Gets or sets the <see cref="DbSet{TEntity}" /> for Users.
    /// </summary>
    public DbSet<User> Users { get; init; } = null!;

    /// <summary>
    ///     Configures the model that was discovered by convention from the entity types
    ///     exposed in <see cref="DbSet{TEntity}" /> properties on your derived context.
    ///     The resulting model may be cached and re-used for subsequent instances of your derived context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations from the current assembly to the model builder.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityServerContext).Assembly);
    }
}