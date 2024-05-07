using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria;

public class GetUsersByCriteriaUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<GetUsersResponse> ExecuteAsync(
        GetUsersRequest request)
    {
        var filter = request.Filter;
        var sorter = request.Sorter;
        var pagination = request.Pagination;

        var criteriaList = new List<ICriteria<User>>
        {
            new UserIdCriteria(filter.Id),
            new UsernameCriteria(filter.UserName),
            new UserEmailCriteria(filter.Email),
            new UserFirstNameCriteria(filter.FirstName),
            new UserLastNameCriteria(filter.LastName),
            new UserIsBlockedCriteria(filter.IsBlocked)
        };

        var users = await unitOfWork.UserRepository.GetByCriteriaAsync(criteriaList, sorter, pagination);
        var response = mapper.Map<GetUsersResponse>(users);
        return response;
    }
}