namespace IdentityServer.Application.Commons.DataTransferObjects.Requests;

/// <summary>
/// Represents sorting options for requests that support sorting.
/// </summary>
public class SortingOptionsRequest
{
    /// <summary>
    /// Gets or sets the property name by which to order the results.
    /// </summary>
    /// <value>The property name to order by. Null if not specified, indicating default sorting.</value>
    public string? OrderBy { get; set; }
    
    /// <summary>
    /// Gets or sets the order type for sorting.
    /// </summary>
    /// <value>The order type, typically "asc" for ascending or "desc" for descending. Null if not specified, allowing for default order type to be used.</value>
    public string? OrderType { get; set; }
}