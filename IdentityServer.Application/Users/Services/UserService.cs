using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation.DataTransferObjects;
using IdentityServer.Application.Users.Interfaces;
using IdentityServer.Application.Users.UseCases.CreateUser;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.CreateUserByAzureAd;
using IdentityServer.Application.Users.UseCases.GetUserByEmail;
using IdentityServer.Application.Users.UseCases.GetUserByEmail.DataTransferObjects;
using IdentityServer.Application.Users.UseCases.GetUserById;
using IdentityServer.Application.Users.UseCases.GetUserById.DataTransferObjects.Response;
using IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId;
using IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId.DataTransferObjects;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.UpdateMicrosoftId;
using IdentityServer.Application.Users.UseCases.UpdateMicrosoftId.DataTransferObjects;
using IdentityServer.Application.Users.UseCases.UpdateUser;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.Services;

public class UserService(
    GetUsersByCriteriaUseCase getUsersByCriteriaByCriteriaUseCase,
    GetUserByIdUseCase getUserByIdUseCase,
    GetUserByEmailUseCase getUserByEmailUseCase,
    GetUserByMicrosoftId getUserByMicrosoftId,
    CreateUserUseCase createUserUseCase,
    CreateUserByAzureAdUseCase createUserByAzureAdUseCase,
    UpdateUserUseCase updateUserUseCase,
    UpdateMicrosoftIdUseCase updateMicrosoftIdUseCase,
    SoftDeleteUserUseCase softDeleteUserUseCase) : IUserService
{
    public async Task<GetUsersByCriteriaResponse> GetUsersByCriteriaAsync(
        GetUsersByCriteriaRequest byCriteriaRequest)
    {
        return await getUsersByCriteriaByCriteriaUseCase.ExecuteAsync(byCriteriaRequest);
    }

    public async Task<GetUserByIdResponse> GetUserByIdAsync(Guid id)
    {
        return await getUserByIdUseCase.ExecuteAsync(id);
    }

    public async Task<CreateUserResponse> AddUserAsync(CreateUserRequest request)
    {
        return await createUserUseCase.ExecuteAsync(request);
    }

    public async Task AddUserAsync(AzureAdUserDto request)
    {
        await createUserByAzureAdUseCase.ExecuteAsync(request);
    }

    public async Task<UpdateUserResponse> UpdateUserAsync(Guid id, UpdateUserRequest request)
    {
        return await updateUserUseCase.ExecuteAsync(id, request);
    }

    public async Task<SoftDeleteUserResponse> SoftDeleteUserAsync(Guid id)
    {
        return await softDeleteUserUseCase.ExecuteAsync(id);
    }

    public async Task<GetUserGetUserByMicrosoftIdResponse?> GetByMicrosoftIdAsync(string microsoftId)
    {
        return await getUserByMicrosoftId.ExecuteAsync(microsoftId);
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

    public async Task<UpdateMicrosoftIdResponse> UpdateMicrosoftIdAsync(Guid id, string microsoftId)
    {
        return await updateMicrosoftIdUseCase.ExecuteAsync(id, microsoftId);
    }

    public async Task<GetUserByEmailResponse?> GetByEmailAsync(string email)
    {
        return await getUserByEmailUseCase.ExecuteAsync(email);
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