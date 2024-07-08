using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId.DataTransferObjects;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId;

/// <summary>
/// Handles the operation of retrieving a user by their Microsoft ID.
/// </summary>
/// <param name="unitOfWork">The unit of work for database operations.</param>
/// <param name="mapper">The AutoMapper instance for mapping domain entities to DTOs.</param>
public class GetUserByMicrosoftId(IUnitOfWork unitOfWork, IMapper mapper)
{
    /// <summary>
    /// Executes the use case of getting a user by their Microsoft ID.
    /// </summary>
    /// <param name="microsoftId">The Microsoft ID of the user to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="GetUserGetUserByMicrosoftIdResponse"/> DTO if the user is found; otherwise, null.</returns>
    public async Task<GetUserGetUserByMicrosoftIdResponse?> ExecuteAsync(string microsoftId)
    {
        var user = await unitOfWork.UserRepository.GetByMicrosoftIdAsync(microsoftId);
        var response = mapper.Map<GetUserGetUserByMicrosoftIdResponse?>(user);
        return response;
    }
}