using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Implementations;

public class Specification<T>(
    IReadOnlyList<ICriteria<T>> filters,
    ISorter sortingOptions,
    IPagination paginationOptions) : ISpecification<T>
{
    public IReadOnlyList<ICriteria<T>> Filters { get; init; } = filters;
    public ISorter SortingOptions { get; init; } = sortingOptions;
    public IPagination PaginationOptions { get; init; } = paginationOptions;
}