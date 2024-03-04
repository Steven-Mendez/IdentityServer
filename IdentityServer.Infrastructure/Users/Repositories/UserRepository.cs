using IdentityServer.Domain.Users.Entities;
using IdentityServer.Domain.Users.Exceptions;
using IdentityServer.Domain.Users.Interfaces;
using IdentityServer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Users.Repository;

public class UserRepository(IdentityServerContext context) : IUserRepository
{
    private readonly IdentityServerContext _context = context;

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _context.Users
            .OrderBy(u => u.FirstName)
            .ThenBy(u => u.LastName)
            .ToListAsync();
        return users;
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        var userNotExists = user is null;

        if (userNotExists)
        {
            var identifier = id.ToString();
            var identifierType = "id";
            throw new UserNotFoundException(identifier, identifierType);
        }

        return user!;
    }

    public async Task<User> AddAsync(User entity)
    {
        var isEmailUnique = await IsEmailUniqueAsync(entity.Email);

        if (!isEmailUnique)
            throw new EmailAlreadyExistsException(entity.Email);

        var isUserNameUnique = await IsUserNameUniqueAsync(entity.UserName);

        if (!isUserNameUnique)
            throw new UserNameAlreadyExistsException(entity.UserName);

        var entityEntry = await _context.Users.AddAsync(entity);
        var adedUser = entityEntry.Entity;
        return adedUser;
    }

    public async Task UpdateAsync(Guid id, User entity)
    {
        var userToUpdate = await GetByIdAsync(id);

        userToUpdate!.UserName = entity.UserName;
        userToUpdate.Email = entity.Email;
        userToUpdate.FirstName = entity.FirstName;
        userToUpdate.LastName = entity.LastName;
        userToUpdate.Password = entity.Password;
    }

    public async Task DeleteAsync(Guid id)
    {
        var userToDelete = await _context.Users.FindAsync(id);

        if (userToDelete is null)
        {
            var identifier = id.ToString();
            var identifierType = "id";
            throw new UserNotFoundException(identifier, identifierType);
        }

        userToDelete.IsDeleted = true;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }

    public async Task<User?> GetByUserNameAsync(string userName)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        return user;
    }

    public async Task<User?> GetByUserNameOrEmailAsync(string userNameOrEmail)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userNameOrEmail || u.Email == userNameOrEmail);
        return user;
    }

    public async Task<IEnumerable<User>> GetActiveUsersAsync()
    {
        var activeUsers = await _context.Users.Where(u => !u.IsBlocked).ToListAsync();
        return activeUsers;
    }

    public async Task<IEnumerable<User>> GetBlockedUsersAsync()
    {
        var blockedUsers = await _context.Users.Where(u => u.IsBlocked).ToListAsync();
        return blockedUsers;
    }

    public async Task<bool> UserExistsAsync(string userNameOrEmail)
    {
        var user = await GetByUserNameOrEmailAsync(userNameOrEmail);

        var userExists = user is not null;

        return userExists;
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        var emailExists = await _context.Users.AnyAsync(u => u.Email == email);
        return !emailExists;
    }

    public async Task<bool> IsUserNameUniqueAsync(string userName)
    {
        var userNameExists = await _context.Users.AnyAsync(u => u.UserName == userName);
        return !userNameExists;
    }

    public async Task ToggleBlockStatusAsync(Guid userId, bool blockStatus)
    {
        var user = await GetByIdAsync(userId);
        user.IsBlocked = blockStatus;
    }

    public async Task<User> AuthenticateAsync(string userNameOrEmail, string password)
    {
        var user = await GetByUserNameOrEmailAsync(userNameOrEmail);

        var userNotExists = user is null;

        if (userNotExists)
            throw new AuthenticationFailedException();

        var passwordNotMatch = !password.Equals(user!.Password);

        if (passwordNotMatch)
            throw new AuthenticationFailedException();

        return user;
    }
}
