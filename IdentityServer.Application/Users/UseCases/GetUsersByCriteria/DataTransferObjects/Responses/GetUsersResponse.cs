namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;

public class GetUsersResponse
{
    public IEnumerable<GetUserResponse> Users { get; init; } = default!;
    public int TotalRecords { get; init; }
}