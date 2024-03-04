using API.Users.Repository;
using IdentityServer.Domain.Users.Entities;
using IdentityServer.Infrastructure.Data;
using IdentityServer.Infrastructure.UnitsOfWork;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.InfrastructureTests.Users;

public class GetAllUsersUnitTest
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnOrderedUsers()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<IdentityServerContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

        using var context = new IdentityServerContext(options);

        var users = new List<User>
            {
                new User
                {
                    Id = Guid.Parse("aa435ca3-4924-4433-88de-f27758f05a64"),
                    UserName = "user1",
                    Email = "user1@user1.com",
                    Password = @"P@ssw0rd",
                    FirstName = "user1",
                    LastName = "user1",
                    Avatar = @"https://randomuser.me/api/portraits/men/2.jpg",
                    IsBlocked = true,
                    CreatedBy = Guid.Parse("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f")
                },
                new User
                {
                    Id = Guid.Parse("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f"),
                    UserName = "admin",
                    Email = "admin@admin.com",
                    Password = @"P@ssw0rd",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Avatar = @"https://randomuser.me/api/portraits/men/1.jpg",
                    IsBlocked = false,
                    CreatedBy = Guid.Parse("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f")
                },
            };

        context.Users.AddRange(users);
        context.SaveChanges();

        var userRepository = new UserRepository(context);

        var unitOfWork = new UnitOfWork(context, userRepository);

        // Act
        var result = (await unitOfWork.UserRepository.GetAllAsync()).ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("admin", result[0].UserName);
        Assert.Equal("user1", result[1].UserName);
    }
}
