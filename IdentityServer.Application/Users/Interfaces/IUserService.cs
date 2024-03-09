using IdentityServer.Application.Users.UseCases.CreateUser.DTOS.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DTOS.Responses;
using IdentityServer.Application.Users.UseCases.GetAllUsers.DTO.Responses;
using IdentityServer.Application.Users.UseCases.GetFilteredSortedPaginatedUsers;
using IdentityServer.Application.Users.UseCases.GetUserById.DTO.Response;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DTO.Response;
using IdentityServer.Application.Users.UseCases.UpdateUser.DTO.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DTO.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.Interfaces;

public interface IUserService
{
    Task<IEnumerable<GetAllUsersResponse>> GetAllUsersAsync();
    Task<GetFilteredSortedPaginatedUsersResponse> GetFilteredSortedPaginatedUsersAsync(GetFilteredSortedPaginatedUsersRequest request);
    Task<GetUserByIdResponse> GetUserByIdAsync(Guid id);
    Task<CreateUserResponse> AddUserAsync(CreateUserRequest request);
    Task<UpdateUserResponse> UpdateUserAsync(Guid id, UpdateUserRequest request);
    Task<SoftDeleteUserResponse> SoftDeleteUserAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUserNameAsync(string userName);
    Task<User?> GetByUserNameOrEmailAsync(string userNameOrEmail);
    Task<IEnumerable<User>> GetActiveUsersAsync();
    Task<IEnumerable<User>> GetBlockedUsersAsync();
    Task<bool> UserExistsAsync(string userNameOrEmail);
    Task<bool> IsEmailUniqueAsync(string email);
    Task<bool> IsUserNameUniqueAsync(string userName);
    Task<User> ToggleBlockStatusAsync(Guid userId, bool blockStatus);
    Task<User> AuthenticateAsync(string userNameOrEmail, string password);
}
