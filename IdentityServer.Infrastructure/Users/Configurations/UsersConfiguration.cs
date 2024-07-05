using IdentityServer.Domain.Users.Entities;
using IdentityServer.Infrastructure.Users.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.Infrastructure.Users.Configurations;

/// <summary>
/// Configures the entity model for the User entity.
/// </summary>
public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    /// <summary>
    /// Configures the User entity.
    /// This includes setting up properties, indexes, query filters, and seed data.
    /// </summary>
    /// <param name="builder">Provides a simple API for configuring an EntityTypeBuilder for the User entity.</param>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilter(builder);
        ConfigureSeedData(builder);
    }

    /// <summary>
    /// Configures properties for the User entity.
    /// This includes primary key, default values, types, and restrictions.
    /// </summary>
    /// <param name="builder">EntityTypeBuilder for the User entity.</param>
    private static void ConfigureProperties(EntityTypeBuilder<User> builder)
    {
        ConfigurePrimaryKey(builder);
        ConfigureDefaultValues(builder);
        ConfigureTypes(builder);
        ConfigureRestrictions(builder);
    }

    /// <summary>
    /// Configures the primary key for the User entity.
    /// </summary>
    /// <param name="builder">EntityTypeBuilder for the User entity.</param>
    private static void ConfigurePrimaryKey(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }

    /// <summary>
    /// Configures column types for the User entity.
    /// This includes setting specific types for dates and potentially other properties.
    /// </summary>
    /// <param name="builder">EntityTypeBuilder for the User entity.</param>
    private static void ConfigureTypes(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.CreatedAt).HasColumnType("datetime2");
        builder.Property(x => x.UpdatedAt).HasColumnType("datetime2");
        builder.Property(x => x.DeletedAt).HasColumnType("datetime2");
    }

    /// <summary>
    /// Configures restrictions for the User entity properties.
    /// This includes setting maximum lengths and required fields.
    /// </summary>
    /// <param name="builder">EntityTypeBuilder for the User entity.</param>
    private static void ConfigureRestrictions(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.MicrosoftId).HasMaxLength(255);
        builder.Property(x => x.FirstName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(255);
        builder.Property(x => x.Password).HasMaxLength(255);
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.UserName).HasMaxLength(255);
        builder.Property(x => x.Avatar).HasMaxLength(255);
    }

    /// <summary>
    /// Configures default values for the User entity properties.
    /// This includes setting defaults for boolean flags and using SQL for date defaults.
    /// </summary>
    /// <param name="builder">EntityTypeBuilder for the User entity.</param>
    private static void ConfigureDefaultValues(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.IsBlocked).HasDefaultValue(false);
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
    }

    /// <summary>
    /// Configures indexes for the User entity.
    /// This includes unique constraints and filters for soft deletes.
    /// </summary>
    /// <param name="builder">EntityTypeBuilder for the User entity.</param>
    private static void ConfigureIndexes(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.UserName).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.IsDeleted).HasFilter("IsDeleted = 0");
    }

    /// <summary>
    /// Configures a query filter for the User entity to exclude logically deleted entries.
    /// </summary>
    /// <param name="builder">EntityTypeBuilder for the User entity.</param>
    private static void ConfigureQueryFilter(EntityTypeBuilder<User> builder)
    {
        builder.HasQueryFilter(x => !x.IsDeleted);
    }

    /// <summary>
    /// Configures seed data for the User entity.
    /// This includes providing initial data for the database.
    /// </summary>
    /// <param name="builder">EntityTypeBuilder for the User entity.</param>
    private static void ConfigureSeedData(EntityTypeBuilder<User> builder)
    {
        builder.HasData(UserSeedData.Users);
    }
}