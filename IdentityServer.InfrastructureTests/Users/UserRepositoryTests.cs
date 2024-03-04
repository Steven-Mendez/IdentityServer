using API.Users.Repository;
using IdentityServer.Domain.Users.Entities;
using IdentityServer.Infrastructure.Data;
using IdentityServer.Infrastructure.UnitsOfWork;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.InfrastructureTests.Users;

public class UserRepositoryTests
{
    private static IdentityServerContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<IdentityServerContext>()
            .UseInMemoryDatabase(databaseName: $"InMemoryDatabase-{Guid.NewGuid()}")
            .Options;

        return new IdentityServerContext(options);
    }

    private static async Task<(UnitOfWork unitOfWork, UserRepository userRepository, IdentityServerContext context)> SetupUnitOfWorkWithUsersAsync(List<User> users)
    {
        var context = GetInMemoryDbContext();

        context.Users.AddRange(users);
        await context.SaveChangesAsync();

        var userRepository = new UserRepository(context);
        var unitOfWork = new UnitOfWork(context, userRepository);

        return (unitOfWork, userRepository, context);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOrderedUsers()
    {
        // Arrange
        List<User> users =
        [
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
            ];

        var (unitOfWork, _, context) = await SetupUnitOfWorkWithUsersAsync(users);

        // Act
        var result = (await unitOfWork.UserRepository.GetAllAsync()).ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("admin", result[0].UserName);
        Assert.Equal("user1", result[1].UserName);

        await context.DisposeAsync();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnUser()
    {
        // Arrange
        List<User> users =
        [
                new User
                {
                    Id = Guid.Parse("aa435ca3-4924-4433-88de-f27758f05a64"),
                    UserName = "user1",
                    Email = "user1@user1",
                    Password = @"P@ssw0rd",
                    FirstName = "user1",
                    LastName = "user1",
                    Avatar = @"https://randomuser.me/api/port/2.jpg",
                    IsBlocked = false,
                    CreatedBy = Guid.Parse("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f")
                }
        ];

        var (unitOfWork, _, context) = await SetupUnitOfWorkWithUsersAsync(users);

        // Act
        var result = await unitOfWork.UserRepository.GetByIdAsync(Guid.Parse("aa435ca3-4924-4433-88de-f27758f05a64"));

        // Assert
        Assert.Equal("user1", result.UserName);
        Assert.Equal("user1@user1", result.Email);
        Assert.Equal(@"P@ssw0rd", result.Password);
        Assert.Equal("user1", result.FirstName);
        Assert.Equal("user1", result.LastName);
        Assert.Equal(@"https://randomuser.me/api/port/2.jpg", result.Avatar);
        Assert.False(result.IsBlocked);
        Assert.Equal(Guid.Parse("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f"), result.CreatedBy);

        await context.DisposeAsync();
    }

    [Fact]
    public async Task AddAsync_ShouldAddUser()
    {
        // Arrange
        var userId = Guid.Parse("aa435ca3-4924-4433-88de-f27758f05a64");

        var user = new User
        {
            Id = userId,
            UserName = "user1",
            Email = "user1@user1",
            Password = @"P@ssw0rd",
            FirstName = "user1",
            LastName = "user1",
            Avatar = @"https://randomuser.me/api/port/2.jpg",
            IsBlocked = false,
            CreatedBy = Guid.Parse("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f")
        };

        var (unitOfWork, _, context) = await SetupUnitOfWorkWithUsersAsync(new List<User>());

        // Act
        await unitOfWork.UserRepository.AddAsync(user);
        await unitOfWork.SaveChangesAsync();

        var count = await context.Users.CountAsync();
        var result = await context.Users.FindAsync(userId);

        // Assert
        Assert.True(result is not null);
        Assert.Equal(1, count);
        Assert.Equal(userId, result.Id);
        Assert.Equal("user1", result.UserName);
        Assert.Equal("user1@user1", result.Email);
        Assert.Equal(@"P@ssw0rd", result.Password);
        Assert.Equal("user1", result.FirstName);
        Assert.Equal("user1", result.LastName);
        Assert.Equal(@"https://randomuser.me/api/port/2.jpg", result.Avatar);
        Assert.False(result.IsBlocked);
        Assert.Equal(Guid.Parse("6e7f4c0b-3b45-4a1c-a48d-9e531dd6931f"), result.CreatedBy);

        await context.DisposeAsync();
    }
}
