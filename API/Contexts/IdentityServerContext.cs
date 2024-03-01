using API.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Contexts;

public class IdentityServerContext(DbContextOptions<IdentityServerContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityServerContext).Assembly);
    }
}
