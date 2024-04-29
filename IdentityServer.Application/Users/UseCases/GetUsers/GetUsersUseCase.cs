using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetUsers.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.GetUsers.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetUsers;

public class GetUsersUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<GetUsersResponse> ExecuteAsync(
        GetUsersRequest request)
    {
        var filter = request.Filter;
        var sorter = request.Sorter;
        var pagination = request.Pagination;
        var users = await unitOfWork.UserRepository.GetFilteredSortedPaginatedAsync(filter, sorter, pagination);
        var response = mapper.Map<GetUsersResponse>(users);
        return response;
    }
}