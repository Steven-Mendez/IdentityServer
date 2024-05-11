namespace IdentityServer.Domain.Interfaces;

public interface ISpecification<T>
{
    IReadOnlyList<ICriteria<T>> Filters { get; init; }
    ISortingOptions SortingOptions { get; init; }
    IPaginationOptions PaginationOptionsOptions { get; init; }
}