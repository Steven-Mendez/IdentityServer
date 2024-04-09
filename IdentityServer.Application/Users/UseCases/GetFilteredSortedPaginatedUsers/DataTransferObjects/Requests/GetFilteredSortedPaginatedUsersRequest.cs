using IdentityServer.Application.Implementations;
using IdentityServer.Application.Users.Filters;

namespace IdentityServer.Application.Users.UseCases.GetFilteredSortedPaginatedUsers.DataTransferObjects.Requests;

public class GetFilteredSortedPaginatedUsersRequest(UserFilter? filter, Sorter? sorter, Pagination pagination)
{
    public UserFilter? Filter { get; set; } = filter;

    public Sorter? Sorter { get; set; } = sorter;

    public Pagination Pagination { get; set; } = pagination;
}