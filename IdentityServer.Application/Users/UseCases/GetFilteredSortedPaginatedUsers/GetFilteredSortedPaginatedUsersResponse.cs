namespace IdentityServer.Application.Users.UseCases.GetFilteredSortedPaginatedUsers;

public class GetFilteredSortedPaginatedUsersResponse
{
    public IEnumerable<GetFilteredSortedPaginatedUserResponse> Users { get; set; } = default!;
    public int TotalRecords { get; set; }
}