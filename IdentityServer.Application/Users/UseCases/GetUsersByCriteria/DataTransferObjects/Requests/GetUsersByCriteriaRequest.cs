using IdentityServer.Application.Commons.DataTransferObjects.Requests;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Requests;

/// <summary>
/// Represents a request to retrieve users based on specified criteria, sorting options, and pagination options.
/// </summary>
/// <param name="filter">The filtering criteria for users.</param>
/// <param name="sortingOptions">The sorting options for the result set.</param>
/// <param name="paginationOptions">The pagination options for the result set.</param>
public class GetUsersByCriteriaRequest(
    GetUserByCriteriaFilterRequest filter,
    SortingOptionsRequest sortingOptions,
    PaginationOptionsRequest paginationOptions)
{
    /// <summary>
    /// Gets the filtering criteria for users.
    /// </summary>
    public GetUserByCriteriaFilterRequest Filter { get; } = filter;

    /// <summary>
    /// Gets the sorting options for the result set.
    /// </summary>
    public SortingOptionsRequest SortingOptions { get; } = sortingOptions;

    /// <summary>
    /// Gets the pagination options for the result set.
    /// </summary>
    public PaginationOptionsRequest PaginationOptions { get; } = paginationOptions;
}