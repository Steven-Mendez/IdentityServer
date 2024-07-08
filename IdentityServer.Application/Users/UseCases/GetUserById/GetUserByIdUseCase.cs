using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserById.DataTransferObjects.Response;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetUserById;

/// <summary>
///     Use case for retrieving a user by their unique identifier.
/// </summary>
/// <param name="unitOfWork">The unit of work abstraction for accessing repositories.</param>
/// <param name="mapper">The AutoMapper instance for mapping domain entities to DTOs.</param>
public class GetUserByIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    /// <summary>
    ///     Executes the use case to retrieve a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user to retrieve.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the
    ///     <see cref="GetUserByIdResponse" /> DTO.
    /// </returns>
    public async Task<GetUserByIdResponse> ExecuteAsync(Guid id)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(id);

        var response = mapper.Map<GetUserByIdResponse>(user);

        return response;
    }
}