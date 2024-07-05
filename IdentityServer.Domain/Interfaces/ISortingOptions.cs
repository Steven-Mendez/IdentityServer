using IdentityServer.Domain.Enums;

namespace IdentityServer.Domain.Interfaces;

/// <summary>
/// Represents sorting options for specifying how data should be ordered.
/// </summary>
public interface ISortingOptions
{
    /// <summary>
    /// Gets or initializes the property name by which to order the data.
    /// </summary>
    string? OrderBy { get; init; }
    
    /// <summary>
    /// Gets or initializes the sort order type (ascending or descending).
    /// </summary>
    SortOrderType OrderType { get; init; }
}