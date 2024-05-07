using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria;

public class GetUsersByCriteriaUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<GetUsersByCriteriaResponse> ExecuteAsync(
        GetUsersByCriteriaRequest byCriteriaRequest)
    {
        var filter = byCriteriaRequest.Filter;
        var sorter = byCriteriaRequest.Sorter;
        var pagination = byCriteriaRequest.Pagination;

        var criteriaList = new List<ICriteria<User>>
        {
            new UserIdCriteria(filter.Id),
            new UsernameCriteria(filter.UserName),
            new UserEmailCriteria(filter.Email),
            new UserFirstNameCriteria(filter.FirstName),
            new UserLastNameCriteria(filter.LastName),
            new UserIsBlockedCriteria(filter.IsBlocked),
            new UserDateRangeCriteria(filter.StartDate, filter.EndDate)
        };

        var users = await unitOfWork.UserRepository.GetByCriteriaAsync(criteriaList, sorter, pagination);
        var response = mapper.Map<GetUsersByCriteriaResponse>(users);
        return response;
    }
}