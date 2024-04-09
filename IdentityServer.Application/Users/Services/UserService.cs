using IdentityServer.Application.Users.Interfaces;
using IdentityServer.Application.Users.UseCases.CreateUser;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.GetAllUsers;
using IdentityServer.Application.Users.UseCases.GetAllUsers.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.GetFilteredSortedPaginatedUsers;
using IdentityServer.Application.Users.UseCases.GetUserById;
using IdentityServer.Application.Users.UseCases.GetUserById.DataTransferObjects.Response;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.UpdateUser;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.Services;

public class UserService(
    GetAllUsersUseCase getAllUsersUseCase,
    GetFilteredSortedPaginatedUsersUseCase getFilteredSortedPaginatedUsersUseCase,
    GetUserByIdUseCase getUserByIdUseCase,
    CreateUserUseCase createUserUseCase,
    UpdateUserUseCase updateUserUseCase,
    SoftDeleteUserUseCase softDeleteUserUseCase) : IUserService
{
    public async Task<IEnumerable<GetAllUsersResponse>> GetAllUsersAsync()
    {
        var users = await getAllUsersUseCase.ExecuteAsync();
        return users;
    }

    public async Task<GetFilteredSortedPaginatedUsersResponse> GetFilteredSortedPaginatedUsersAsync(
        GetFilteredSortedPaginatedUsersRequest request)
    {
        return await getFilteredSortedPaginatedUsersUseCase.ExecuteAsync(request);
    }

    public async Task<GetUserByIdResponse> GetUserByIdAsync(Guid id)
    {
        return await getUserByIdUseCase.ExecuteAsync(id);
    }

    public async Task<CreateUserResponse> AddUserAsync(CreateUserRequest request)
    {
        return await createUserUseCase.ExecuteAsync(request);
    }

    public async Task<UpdateUserResponse> UpdateUserAsync(Guid id, UpdateUserRequest request)
    {
        return await updateUserUseCase.ExecuteAsync(id, request);
    }

    public async Task<SoftDeleteUserResponse> SoftDeleteUserAsync(Guid id)
    {
        return await softDeleteUserUseCase.ExecuteAsync(id);
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