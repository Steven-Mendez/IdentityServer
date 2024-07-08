namespace IdentityServer.Application.Commons.DataTransferObjects.Requests;

/// <summary>
///     Represents pagination options for requests that support pagination.
/// </summary>
public class PaginationOptionsRequest
{
    /// <summary>
    ///     Gets the page number for pagination.
    /// </summary>
    /// <value>The page number. Null if not specified, indicating that pagination is not requested.</value>
    public int? PageNumber { get; init; }

    /// <summary>
    ///     Gets the size of the page for pagination.
    /// </summary>
    /// <value>The size of the page. Null if not specified, allowing for default pagination size to be used.</value>
    public int? PageSize { get; init; }
}