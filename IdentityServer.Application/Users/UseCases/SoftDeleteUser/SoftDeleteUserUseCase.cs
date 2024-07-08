using AutoMapper;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.SoftDeleteUser;


/// <summary>
/// Handles the soft deletion process for users.
/// </summary>
/// <param name="unitOfWork">The unit of work for database transactions.</param>
/// <param name="mapper">The AutoMapper instance for object mapping.</param>
public class SoftDeleteUserUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    /// <summary>
    /// Executes the soft deletion process for a user by their unique identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to be soft deleted.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response after soft deleting the user.</returns>
    public async Task<SoftDeleteUserResponse> ExecuteAsync(Guid userId)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(userId);

        await unitOfWork.UserRepository.DeleteAsync(userId);

        await unitOfWork.SaveChangesAsync();

        var response = mapper.Map<SoftDeleteUserResponse>(user);

        return response;
    }
}