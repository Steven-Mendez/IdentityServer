namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;

public class GetUsersByCriteriaResponse
{
    public IEnumerable<GetUserByCriteriaResponse> Users { get; init; } = default!;
    public int TotalRecords { get; init; }
}