namespace IdentityServer.Application.Users.UseCases.GetFilteredSortedPaginatedUsers.DataTransferObjects.Responses;

public class GetFilteredSortedPaginatedUsersResponse
{
    public IEnumerable<GetFilteredSortedPaginatedUserResponse> Users { get; init; } = default!;
    public int TotalRecords { get; init; }
    public int FilteredRecords { get; init; }
}