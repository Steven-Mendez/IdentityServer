using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Infrastructure.Users.SeedData;

/// <summary>
///     Provides seed data for users to be used in the application's data store.
///     This class contains a static property that holds a collection of initial users.
/// </summary>
public static class UserSeedData
{
    /// <summary>
    ///     Gets a collection of users to be seeded into the application's data store.
    /// </summary>
    /// <value>
    ///     The collection of <see cref="User" /> objects to be seeded.
    /// </value>
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
            CreatedBy = Guid.Parse("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f")
        }
    ];
}