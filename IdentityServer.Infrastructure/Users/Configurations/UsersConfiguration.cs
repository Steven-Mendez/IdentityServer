using IdentityServer.Domain.Users.Entities;
using IdentityServer.Infrastructure.Users.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.Infrastructure.Users.Configurations;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilter(builder);
        ConfigureSeedData(builder);
    }

    private static void ConfigureProperties(EntityTypeBuilder<User> builder)
    {
        ConfigurePrimaryKey(builder);
        ConfigureDefaultValues(builder);
        ConfigureTypes(builder);
        ConfigureRestrictions(builder);
    }

    private static void ConfigurePrimaryKey(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }

    private static void ConfigureTypes(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.CreatedAt).HasColumnType("datetime2");
        builder.Property(x => x.UpdatedAt).HasColumnType("datetime2");
        builder.Property(x => x.DeletedAt).HasColumnType("datetime2");
    }

    private static void ConfigureRestrictions(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(255);
        builder.Property(x => x.Password).HasMaxLength(255);
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.UserName).HasMaxLength(255);
        builder.Property(x => x.Avatar).HasMaxLength(255);
    }

    private static void ConfigureDefaultValues(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.IsBlocked).HasDefaultValue(false);
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.UserName).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.IsDeleted).HasFilter("IsDeleted = 0");
    }

    private static void ConfigureQueryFilter(EntityTypeBuilder<User> builder)
    {
        builder.HasQueryFilter(x => !x.IsDeleted);
    }

    private static void ConfigureSeedData(EntityTypeBuilder<User> builder)
    {
        builder.HasData(UserSeedData.Users);
    }
}