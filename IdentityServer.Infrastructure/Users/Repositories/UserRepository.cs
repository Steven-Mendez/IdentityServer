﻿using IdentityServer.Application.Authentiacion.Interfaces;
using IdentityServer.Domain.Helpers;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;
using IdentityServer.Domain.Users.Exceptions;
using IdentityServer.Domain.Users.Interfaces;
using IdentityServer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Users.Repository;

public class UserRepository(IdentityServerContext context, IPasswordHasher passwordHasher) : IUserRepository
{
    private readonly IdentityServerContext _context = context;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _context.Users
            .OrderBy(u => u.FirstName)
            .ThenBy(u => u.LastName)
            .ToListAsync();
        return users;
    }

    public async Task<(IEnumerable<User> Users, int TotalRecords)> GetFilteredSortedPaginatedAsync(IUserFilter? filter, ISorter? sorting, IPagination pagination)
    {
        var userQuery = _context.Users.AsNoTracking().AsSplitQuery();
        var orignalQuery = userQuery;
        if (filter is not null)
            userQuery = userQuery.ApplyFilters(filter);

        if (sorting is not null)
            userQuery = userQuery.ApplySorting(sorting);

        userQuery = userQuery.ApplyPagination(pagination);

        var users = await userQuery.ToListAsync();
        var totalRecords = await orignalQuery.CountAsync();

        return (users, totalRecords);
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        var userNotExists = user is null;

        if (userNotExists)
            throw new UserNotFoundException(nameof(id), id);

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

        entity.Password = _passwordHasher.Hash(entity.Password);

        var entityEntry = await _context.Users.AddAsync(entity);
        var adedUser = entityEntry.Entity;
        return adedUser;
    }

    public async Task UpdateAsync(Guid id, User entity)
    {
        var anotherUserExistsWithSameEmail = await AnotherUserExistsWithSameEmailAsync(id, entity.Email);

        if (anotherUserExistsWithSameEmail)
            throw new EmailAlreadyExistsException(entity.Email);

        var anotherUserExistsWithSameUserName = await AnotherUserExistsWithSameUserNameAsync(id, entity.UserName);

        if (anotherUserExistsWithSameUserName)
            throw new UserNameAlreadyExistsException(entity.UserName);

        _context.Users.Update(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var userToDelete = await _context.Users.FindAsync(id);

        if (userToDelete is null)
            throw new UserNotFoundException(nameof(id), id);

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

    public async Task<bool> AnotherUserExistsWithSameEmailAsync(Guid userId, string email)
    {
        var user = await GetByEmailAsync(email);

        var userExists = user is not null;

        var anotherUserExists = userExists && user!.Id != userId;

        return anotherUserExists;
    }

    public async Task<bool> AnotherUserExistsWithSameUserNameAsync(Guid userId, string userName)
    {
        var user = await GetByUserNameAsync(userName);

        var userExists = user is not null;

        var anotherUserExists = userExists && user!.Id != userId;

        return anotherUserExists;
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
        var propertyName = userNameOrEmail.Contains('@') ? "Email" : "UserName";

        if (userNotExists)
            throw new AuthenticationFailedException(propertyName);

        var passwordNotMatch = !_passwordHasher.Verify(password, user!.Password);

        if (passwordNotMatch)
            throw new AuthenticationFailedException(propertyName);

        return user;
    }
}
