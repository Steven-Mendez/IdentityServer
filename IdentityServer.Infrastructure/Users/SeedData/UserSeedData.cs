using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Infrastructure.Users.SeedData;

public static class UserSeedData
{
    public static IEnumerable<User> Users =>
    [
        new User
        {
            Id = Guid.Parse("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f"),
            UserName = "admin",
            Email = "admin@admin.com",
            Password = @"3qgXD8CJJvw+H4DkENHDqQ==;zbm8kyh0QCLHoKBgut6mtT8jqCIRcv9vNEKTnbtTGaE=",
            FirstName = "Admin",
            LastName = "Admin",
            Avatar = @"https://randomuser.me/api/portraits/men/1.jpg",
            IsBlocked = false,
            CreatedBy = Guid.Parse("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f"),
        }
    ];
}