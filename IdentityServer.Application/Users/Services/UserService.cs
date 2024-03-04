using IdentityServer.Application.Users.Interfaces;
using IdentityServer.Application.Users.UseCases.GetAllUsers;
using IdentityServer.Application.Users.UseCases.GetAllUsers.DTO.Responses;
using IdentityServer.Application.Users.UseCases.GetUserById;
using IdentityServer.Application.Users.UseCases.GetUserById.DTO.Response;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.Services;

public class UserService(GetAllUsersUseCase getAllUsersUseCase, GetUserByIdUseCase getUserByIdUseCase) : IUserService
{
    private readonly GetAllUsersUseCase _getAllUsersUseCase = getAllUsersUseCase;
    private readonly GetUserByIdUseCase _getUserByIdUseCase = getUserByIdUseCase;

    public async Task<IEnumerable<GetAllUsersResponse>> GetAllUsersAsync()
    {
        var users = await _getAllUsersUseCase.ExecuteAsync();
        return users;
    }

    public Task<GetUserByIdResponse> GetUserByIdAsync(Guid id)
    {
        return _getUserByIdUseCase.ExecuteAsync(id);
    }
    public Task<User> AddUserAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserAsync(Guid id, User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByUserNameAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByUserNameOrEmailAsync(string userNameOrEmail)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetActiveUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetBlockedUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> AuthenticateAsync(string userNameOrEmail, string password)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserExistsAsync(string userNameOrEmail)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsEmailUniqueAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsUserNameUniqueAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<User> ToggleBlockStatusAsync(Guid userId, bool blockStatus)
    {
        throw new NotImplementedException();
    }
}
