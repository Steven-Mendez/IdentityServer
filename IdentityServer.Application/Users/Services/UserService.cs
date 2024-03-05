using IdentityServer.Application.Users.Interfaces;
using IdentityServer.Application.Users.UseCases.CreateUser;
using IdentityServer.Application.Users.UseCases.CreateUser.DTOS.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DTOS.Responses;
using IdentityServer.Application.Users.UseCases.GetAllUsers;
using IdentityServer.Application.Users.UseCases.GetAllUsers.DTO.Responses;
using IdentityServer.Application.Users.UseCases.GetUserById;
using IdentityServer.Application.Users.UseCases.GetUserById.DTO.Response;
using IdentityServer.Application.Users.UseCases.UpdateUser;
using IdentityServer.Application.Users.UseCases.UpdateUser.DTO.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DTO.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.Services;

public class UserService(GetAllUsersUseCase getAllUsersUseCase, GetUserByIdUseCase getUserByIdUseCase, CreateUserUseCase createUserUseCase, UpdateUserUseCase updateUserUseCase) : IUserService
{
    private readonly GetAllUsersUseCase _getAllUsersUseCase = getAllUsersUseCase;
    private readonly GetUserByIdUseCase _getUserByIdUseCase = getUserByIdUseCase;
    private readonly CreateUserUseCase _createUserUseCase = createUserUseCase;
    private readonly UpdateUserUseCase _updateUserUseCase = updateUserUseCase;

    public async Task<IEnumerable<GetAllUsersResponse>> GetAllUsersAsync()
    {
        var users = await _getAllUsersUseCase.ExecuteAsync();
        return users;
    }

    public async Task<GetUserByIdResponse> GetUserByIdAsync(Guid id)
    {
        return await _getUserByIdUseCase.ExecuteAsync(id);
    }

    public async Task<CreateUserResponse> AddUserAsync(CreateUserRequest request)
    {
        return await _createUserUseCase.ExecuteAsync(request);
    }

    public async Task<UpdateUserResponse> UpdateUserAsync(Guid id, UpdateUserRequest request)
    {
        return await _updateUserUseCase.ExecuteAsync(id, request);
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
