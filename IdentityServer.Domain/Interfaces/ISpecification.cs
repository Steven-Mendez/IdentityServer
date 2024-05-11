namespace IdentityServer.Domain.Interfaces;

public interface ISpecification<T>
{
    IReadOnlyList<ICriteria<T>> Filters { get; init; }
    ISorter SortingOptions { get; init; }
    IPagination PaginationOptions { get; init; }
}