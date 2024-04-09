using AutoMapper;
using IdentityServer.Application.Users.UseCases.GetFilteredSortedPaginatedUsers.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.GetFilteredSortedPaginatedUsers.DataTransferObjects.Responses;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetFilteredSortedPaginatedUsers;

public class GetFilteredSortedPaginatedUsersUseCase(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task<GetFilteredSortedPaginatedUsersResponse> ExecuteAsync(
        GetFilteredSortedPaginatedUsersRequest request)
    {
        var filter = request.Filter;
        var sorter = request.Sorter;
        var pagination = request.Pagination;
        var users = await unitOfWork.UserRepository.GetFilteredSortedPaginatedAsync(filter, sorter, pagination);
        var response = mapper.Map<GetFilteredSortedPaginatedUsersResponse>(users);
        return response;
    }
}