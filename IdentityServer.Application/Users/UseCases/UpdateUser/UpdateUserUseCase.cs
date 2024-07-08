using AutoMapper;
using FluentValidation;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.UpdateUser;

/// <summary>
/// Represents the use case for updating a user.
/// </summary>
/// <param name="unitOfWork">The unit of work for database operations.</param>
/// <param name="mapper">The AutoMapper instance for object-to-object mapping.</param>
/// <param name="validationRules">The validation rules for updating a user.</param>
public class UpdateUserUseCase(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateUserRequest> validationRules)
{
    /// <summary>
    /// Executes the update user use case asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the user to update.</param>
    /// <param name="request">The request containing the user update information.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated user response.</returns>
    public async Task<UpdateUserResponse> ExecuteAsync(Guid id, UpdateUserRequest request)
    {
        await validationRules.ValidateAndThrowAsync(request);

        var user = await unitOfWork.UserRepository.GetByIdAsync(id);

        user = mapper.Map(request, user);

        await unitOfWork.UserRepository.UpdateAsync(id, user);

        await unitOfWork.SaveChangesAsync();

        var response = mapper.Map<UpdateUserResponse>(user);

        return response;
    }
}