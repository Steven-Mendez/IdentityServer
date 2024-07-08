using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Implementations;

/// <summary>
///     Represents pagination options for queries that support pagination.
/// </summary>
/// <param name="pageSize">The size of the page. Null to use the default size.</param>
/// <param name="pageNumber">The number of the current page. Null to start from the beginning.</param>
public class PaginationOptions(int? pageSize, int? pageNumber) : IPaginationOptions
{
    /// <summary>
    ///     Gets the page number for pagination.
    /// </summary>
    /// <value>The page number. Null indicates that pagination is not applied.</value>
    public int? PageNumber { get; } = pageNumber;

    /// <summary>
    ///     Gets the page size for pagination.
    /// </summary>
    /// <value>The size of the page. Null indicates that the default page size should be used.</value>
    public int? PageSize { get; } = pageSize;
}