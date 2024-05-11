using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Implementations;

public class Specification<T>(
    IReadOnlyList<ICriteria<T>> filters,
    ISortingOptions sortingOptions,
    IPaginationOptions paginationOptionsOptions) : ISpecification<T>
{
    public IReadOnlyList<ICriteria<T>> Filters { get; init; } = filters;
    public ISortingOptions SortingOptions { get; init; } = sortingOptions;
    public IPaginationOptions PaginationOptionsOptions { get; init; } = paginationOptionsOptions;
}