using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUserByEmail.DataTransferObjects;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetUserByEmail;

/// <summary>
/// Represents the use case for retrieving a user by their email address.
/// </summary>
/// <param name="unitOfWork">The unit of work for database transactions.</param>
/// <param name="mapper">The AutoMapper instance for object-to-object mapping.</param>
public class GetUserByEmailUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    
    /// <summary>
    /// Executes the use case to retrieve a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the user details
    /// if found; otherwise, null.
    /// </returns>
    public async Task<GetUserByEmailResponse?> ExecuteAsync(string email)
    {
        var user = await unitOfWork.UserRepository.GetByEmailAsync(email);
        var response = mapper.Map<GetUserByEmailResponse?>(user);
        return response;
    }
}