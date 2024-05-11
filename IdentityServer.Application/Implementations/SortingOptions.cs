using IdentityServer.Domain.Enums;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Implementations;

public class SortingOptions(string? orderBy, string? orderType) : ISortingOptions
{
    public string? OrderBy { get; init; } = orderBy;
    public SortOrderType OrderType { get; init; } = GetSortOrder(orderType);

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