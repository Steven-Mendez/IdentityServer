﻿using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.GetUserByEmail.DataTransferObjects;
using IdentityServer.Application.Users.UseCases.GetUserById.DataTransferObjects.Response;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.Interfaces;

public interface IUserService
{
    Task<GetUsersByCriteriaResponse> GetUsersByCriteriaAsync(GetUsersByCriteriaRequest byCriteriaRequest);
    Task<GetUserByIdResponse> GetUserByIdAsync(Guid id);
    Task<CreateUserResponse> AddUserAsync(CreateUserRequest request);
    Task<UpdateUserResponse> UpdateUserAsync(Guid id, UpdateUserRequest request);
    Task<SoftDeleteUserResponse> SoftDeleteUserAsync(Guid id);
    Task<GetUserByEmailResponse?> GetByEmailAsync(string email);
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