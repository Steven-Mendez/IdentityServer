using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Implementations;

/// <summary>
///     Represents a generic specification pattern implementation.
/// </summary>
/// <typeparam name="T">The type of entity for which the specification is defined.</typeparam>
/// <param name="filters">A read-only list of criteria filters to apply.</param>
/// <param name="sortingOptions">Sorting options to apply to the result set.</param>
/// <param name="paginationOptionsOptions">Pagination options to apply to the result set.</param>
public class Specification<T>(
    IReadOnlyList<ICriteria<T>> filters,
    ISortingOptions sortingOptions,
    IPaginationOptions paginationOptionsOptions) : ISpecification<T>
{
    /// <summary>
    ///     Gets the filters applied to the specification.
    /// </summary>
    public IReadOnlyList<ICriteria<T>> Filters { get; init; } = filters;

    /// <summary>
    ///     Gets the sorting options applied to the specification.
    /// </summary>
    public ISortingOptions SortingOptions { get; init; } = sortingOptions;

    /// <summary>
    ///     Gets the pagination options applied to the specification.
    /// </summary>
    public IPaginationOptions PaginationOptionsOptions { get; init; } = paginationOptionsOptions;
}