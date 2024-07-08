using IdentityServer.Application.Authentication.UseCase.AzureAd.AzureAdGetUserInformation.DataTransferObjects;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.GetUserByEmail.DataTransferObjects;
using IdentityServer.Application.Users.UseCases.GetUserById.DataTransferObjects.Response;
using IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId.DataTransferObjects;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.UpdateMicrosoftId.DataTransferObjects;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.Interfaces;

/// <summary>
/// Defines the contract for user-related operations.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Retrieves users based on specified criteria.
    /// </summary>
    /// <param name="byCriteriaRequest">The criteria for filtering users.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the filtered users.</returns>
    Task<GetUsersByCriteriaResponse> GetUsersByCriteriaAsync(GetUsersByCriteriaRequest byCriteriaRequest);
    
    /// <summary>
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user if found; otherwise, null.</returns>
    Task<GetUserByIdResponse> GetUserByIdAsync(Guid id);
    
    /// <summary>
    /// Adds a new user to the system.
    /// </summary>
    /// <param name="request">The user data for creating a new user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response after adding the user.</returns>
    Task<CreateUserResponse> AddUserAsync(CreateUserRequest request);
    
    /// <summary>
    /// Adds a new user to the system based on Azure AD user information.
    /// </summary>
    /// <param name="request">The Azure AD user data for creating a new user.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddUserAsync(AzureAdUserDto request);
    
    /// <summary>
    /// Updates an existing user's information.
    /// </summary>
    /// <param name="id">The unique identifier of the user to update.</param>
    /// <param name="request">The updated user data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response after updating the user.</returns>

    Task<UpdateUserResponse> UpdateUserAsync(Guid id, UpdateUserRequest request);
    
    /// <summary>
    /// Soft deletes a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response after soft deleting the user.</returns>
    Task<SoftDeleteUserResponse> SoftDeleteUserAsync(Guid id);
    
    /// <summary>
    /// Retrieves a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user if found; otherwise, null.</returns>
    Task<GetUserByEmailResponse?> GetByEmailAsync(string email);
    
    /// <summary>
    /// Retrieves a user by their Microsoft ID.
    /// </summary>
    /// <param name="microsoftId">The Microsoft ID of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user if found; otherwise, null.</returns>
    Task<GetUserGetUserByMicrosoftIdResponse?> GetByMicrosoftIdAsync(string microsoftId);
    
    /// <summary>
    /// Retrieves a user by their username.
    /// </summary>
    /// <param name="userName">The username of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user if found; otherwise, null.</returns>
    Task<User?> GetByUserNameAsync(string userName);
    
    /// <summary>
    /// Retrieves a user by their username or email address.
    /// </summary>
    /// <param name="userNameOrEmail">The username or email address of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user if found; otherwise, null.</returns>
    Task<User?> GetByUserNameOrEmailAsync(string userNameOrEmail);
    
    /// <summary>
    /// Retrieves all active users.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of active users.</returns>
    Task<IEnumerable<User>> GetActiveUsersAsync();
    
    /// <summary>
    /// Retrieves all blocked users.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of blocked users.</returns>
    Task<IEnumerable<User>> GetBlockedUsersAsync();
    
    /// <summary>
    /// Checks if a user exists by their username or email address.
    /// </summary>
    /// <param name="userNameOrEmail">The username or email address to check.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains true if the user exists; otherwise, false.</returns>
    Task<bool> UserExistsAsync(string userNameOrEmail);
    
    /// <summary>
    /// Checks if an email address is unique across all users.
    /// </summary>
    /// <param name="email">The email address to check.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains true if the email is unique; otherwise, false.</returns>
    Task<bool> IsEmailUniqueAsync(string email);
    
    /// <summary>
    /// Checks if a username is unique across all users.
    /// </summary>
    /// <param name="userName">The username to check.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains true if the username is unique; otherwise, false.</returns>
    Task<bool> IsUserNameUniqueAsync(string userName);
    
    /// <summary>
    /// Toggles the block status of a user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="blockStatus">The new block status to apply.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated user.</returns>
    Task<User> ToggleBlockStatusAsync(Guid userId, bool blockStatus);
    
    /// <summary>
    /// Authenticates a user based on their username or email and password.
    /// </summary>
    /// <param name="userNameOrEmail">The username or email of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the authenticated user if successful; otherwise, null.</returns>
    Task<User> AuthenticateAsync(string userNameOrEmail, string password);
    
    /// <summary>
    /// Updates the Microsoft ID of a user.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <param name="microsoftId">The new Microsoft ID to set.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response after updating the Microsoft ID.</returns>
    Task<UpdateMicrosoftIdResponse> UpdateMicrosoftIdAsync(Guid id, string microsoftId);
    
    /// <summary>
    /// Registers a new user through self-registration.
    /// </summary>
    /// <param name="request">The self-registration user data.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response after self-registering the user.</returns>
    Task<SelfRegistrationUserResponse> SelfRegistrationUserAsync(SelfRegistrationUserRequest request);
}