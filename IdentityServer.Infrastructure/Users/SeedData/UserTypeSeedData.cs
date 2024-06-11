using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Infrastructure.Users.SeedData;

public static class UserTypeSeedData
{
    public static IEnumerable<UserType> UserTypes =>
    [
        new UserType
        {
            Id = Guid.Parse("19e1ccc0-c3c3-4161-b0c3-b1086d3d97aa"),
            Name = "Local User",
            CreatedBy = Guid.Parse("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f")
        },
        new UserType
        {
            Id = Guid.Parse("c8c24858-68d9-4696-a29b-e9a1f20187de"),
            Name = "Azure User",
            CreatedBy = Guid.Parse("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f")
        }
    ];
}