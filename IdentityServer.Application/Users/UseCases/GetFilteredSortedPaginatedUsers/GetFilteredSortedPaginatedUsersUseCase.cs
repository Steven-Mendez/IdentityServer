using AutoMapper;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Users.UseCases.GetFilteredSortedPaginatedUsers;

public class GetFilteredSortedPaginatedUsersUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetFilteredSortedPaginatedUsersUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetFilteredSortedPaginatedUsersResponse> ExecuteAsync(
        GetFilteredSortedPaginatedUsersRequest request)
    {
        var filter = request.Filter;
        var sorter = request.Sorter;
        var pagination = request.Pagination;
        var users = await _unitOfWork.UserRepository.GetFilteredSortedPaginatedAsync(filter, sorter, pagination);
        var response = _mapper.Map<GetFilteredSortedPaginatedUsersResponse>(users);
        return response;
    }
}