using AutoMapper;
using IdentityServer.Application.Implementations;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria;

/// <summary>
///     Represents the use case for retrieving users based on various criteria.
/// </summary>
/// <param name="unitOfWork">The unit of work for database operations.</param>
/// <param name="mapper">The AutoMapper instance for object mapping.</param>
public class GetUsersByCriteriaUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    /// <summary>
    ///     Executes the use case asynchronously, retrieving users based on the provided criteria.
    /// </summary>
    /// <param name="request">The request containing the criteria for user retrieval.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the
    ///     <see cref="GetUsersByCriteriaResponse" />.
    /// </returns>
    public async Task<GetUsersByCriteriaResponse> ExecuteAsync(
        GetUsersByCriteriaRequest request)
    {
        var filter = request.Filter;
        var sortingOptions = request.SortingOptions;
        var paginationOptions = request.PaginationOptions;

        var specification = new Specification<User>(
            [
                new UserIdCriteria(filter.Id), new UsernameCriteria(filter.UserName),
                new UserEmailCriteria(filter.Email), new UserFirstNameCriteria(filter.FirstName),
                new UserLastNameCriteria(filter.LastName), new UserIsBlockedCriteria(filter.IsBlocked),
                new UserDateRangeCriteria(filter.StartDate, filter.EndDate)
            ],
            new SortingOptions(sortingOptions.OrderBy, sortingOptions.OrderType),
            new PaginationOptions(paginationOptions.PageSize, paginationOptions.PageNumber)
        );

        var users = await unitOfWork.UserRepository.GetByCriteriaAsync(specification);
        var response = mapper.Map<GetUsersByCriteriaResponse>(users);
        return response;
    }
}