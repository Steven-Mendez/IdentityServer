namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;

/// <summary>
/// Represents the response data for a user retrieval operation based on specified criteria.
/// This includes a collection of user data and the total number of records that match the criteria.
/// </summary>
public class GetUsersByCriteriaResponse
{
    /// <summary>
    /// Gets the collection of users that match the specified criteria.
    /// </summary>
    public IEnumerable<GetUserByCriteriaResponse> Users { get; init; } = default!;
    
    /// <summary>
    /// Gets the total number of records that match the specified criteria.
    /// This count includes all users that match the criteria, not just those in the <see cref="Users"/> collection,
    /// which may be limited by pagination.
    /// </summary>
    public int TotalRecords { get; init; }
}