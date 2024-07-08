using AutoMapper;
using FluentValidation;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.CreateUser;

/// <summary>
///     Handles the creation of a new user.
/// </summary>
/// <param name="unitOfWork">The unit of work for database transactions.</param>
/// <param name="mapper">The AutoMapper instance for object-to-object mapping.</param>
/// <param name="validationRules">The validation rules for creating a user.</param>
public class CreateUserUseCase(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateUserRequest> validationRules)
{
    /// <summary>
    ///     Executes the use case to create a new user.
    /// </summary>
    /// <param name="request">The user creation request containing user details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created user response.</returns>
    public async Task<CreateUserResponse> ExecuteAsync(CreateUserRequest request)
    {
        await validationRules.ValidateAndThrowAsync(request);

        var userToAdd = mapper.Map<User>(request);

        var user = await unitOfWork.UserRepository.AddAsync(userToAdd);

        await unitOfWork.SaveChangesAsync();

        var response = mapper.Map<CreateUserResponse>(user);

        return response;
    }
}