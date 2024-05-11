using AutoMapper;
using IdentityServer.Application.Implementations;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria;

public class GetUsersByCriteriaUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
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