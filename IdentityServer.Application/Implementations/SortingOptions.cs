using IdentityServer.Domain.Enums;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Implementations;

/// <summary>
///     Represents sorting options for queries in the application.
/// </summary>
public class SortingOptions(string? orderBy, string? orderType) : ISortingOptions
{
    /// <summary>
    ///     Gets the property name by which the result should be ordered.
    /// </summary>
    public string? OrderBy { get; init; } = orderBy;

    /// <summary>
    ///     Gets the order type (Ascending/Descending) for sorting.
    /// </summary>
    public SortOrderType OrderType { get; init; } = GetSortOrder(orderType);

    /// <summary>
    ///     Determines the <see cref="SortOrderType" /> based on the provided order type string.
    /// </summary>
    /// <param name="orderType">The order type as a string. Expected values are "asc", "ascending", "desc", or "descending".</param>
    /// <returns>The corresponding <see cref="SortOrderType" />. Defaults to Ascending if the input is not recognized.</returns>
    private static SortOrderType GetSortOrder(string? orderType)
    {
        return orderType switch
        {
            "asc" or "ascending" => SortOrderType.Ascending,
            "desc" or "descending" => SortOrderType.Descending,
            _ => SortOrderType.Ascending
        };
    }
}