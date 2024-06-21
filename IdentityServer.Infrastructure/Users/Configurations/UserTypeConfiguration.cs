using IdentityServer.Domain.Users.Entities;
using IdentityServer.Infrastructure.Users.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityServer.Infrastructure.Users.Configurations;

public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
{
    public void Configure(EntityTypeBuilder<UserType> builder)
    {
        ConfigureProperties(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilter(builder);
        ConfigureSeedData(builder);
    }

    private static void ConfigureProperties(EntityTypeBuilder<UserType> builder)
    {
        ConfigurePrimaryKey(builder);
        ConfigureRelationships(builder);
        ConfigureDefaultValues(builder);
        ConfigureTypes(builder);
        ConfigureRestrictions(builder);
    }

    private static void ConfigurePrimaryKey(EntityTypeBuilder<UserType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
    }

    private static void ConfigureRelationships(EntityTypeBuilder<UserType> builder)
    {
        builder.HasMany(ut => ut.Users)
            .WithOne(u => u.UserType)
            .HasForeignKey(u => u.UserTypeId);
    }

    private static void ConfigureTypes(EntityTypeBuilder<UserType> builder)
    {
        builder.Property(x => x.CreatedAt).HasColumnType("datetime");
        builder.Property(x => x.UpdatedAt).HasColumnType("datetime");
        builder.Property(x => x.DeletedAt).HasColumnType("datetime");
    }

    private static void ConfigureRestrictions(EntityTypeBuilder<UserType> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.CreatedBy).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
    }

    private static void ConfigureDefaultValues(EntityTypeBuilder<UserType> builder)
    {
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
    }

    private static void ConfigureIndexes(EntityTypeBuilder<UserType> builder)
    {
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.IsDeleted);
    }

    private static void ConfigureQueryFilter(EntityTypeBuilder<UserType> builder)
    {
        builder.HasQueryFilter(x => !x.IsDeleted);
    }

    private static void ConfigureSeedData(EntityTypeBuilder<UserType> builder)
    {
        builder.HasData(UserTypeSeedData.UserTypes);
    }
}