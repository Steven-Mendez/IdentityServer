namespace IdentityServer.Domain.Interfaces;

/// <summary>
///     Represents a specification interface that defines criteria, sorting options, and pagination options for querying
///     entities of type T.
/// </summary>
/// <typeparam name="T">The type of entity that the specification applies to.</typeparam>
public interface ISpecification<T>
{
    /// <summary>
    ///     Gets or initializes the list of criteria filters to apply when querying entities.
    /// </summary>
    IReadOnlyList<ICriteria<T>> Filters { get; init; }

    /// <summary>
    ///     Gets or initializes the sorting options for ordering queried entities.
    /// </summary>
    ISortingOptions SortingOptions { get; init; }

    /// <summary>
    ///     Gets or initializes the pagination options for limiting and paging through queried entities.
    /// </summary>
    IPaginationOptions PaginationOptionsOptions { get; init; }
}