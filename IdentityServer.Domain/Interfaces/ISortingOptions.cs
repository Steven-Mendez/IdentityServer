using IdentityServer.Domain.Enums;

namespace IdentityServer.Domain.Interfaces;

public interface ISortingOptions
{
    string? OrderBy { get; init; }
    SortOrderType OrderType { get; init; }
}