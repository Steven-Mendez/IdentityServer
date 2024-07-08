using AutoMapper;
using IdentityServer.Application.Users.UseCases.UpdateMicrosoftId.DataTransferObjects;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.UpdateMicrosoftId;


/// <summary>
/// Use case for updating a user's Microsoft ID.
/// </summary>
/// <param name="unitOfWork">The unit of work for database transactions.</param>
/// <param name="mapper">The AutoMapper instance for object mapping.</param>
public class UpdateMicrosoftIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    /// <summary>
    /// Executes the update of a user's Microsoft ID.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <param name="microsoftId">The new Microsoft ID to be set for the user.</param>
    /// <returns>A task that represents the asynchronous operation, yielding the updated user's response data.</returns>
    public async Task<UpdateMicrosoftIdResponse> ExecuteAsync(Guid id, string microsoftId)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(id);

        user.MicrosoftId = microsoftId;
        user.UpdatedAt = DateTime.UtcNow;
        user.UpdatedBy = id;

        await unitOfWork.UserRepository.UpdateAsync(id, user);

        await unitOfWork.SaveChangesAsync();

        var response = mapper.Map<UpdateMicrosoftIdResponse>(user);

        return response;
    }
}