using System.Linq.Expressions;
using System.Reflection;
using IdentityServer.Domain.Enums;
using IdentityServer.Domain.Exceptions;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Domain.Helpers;

/// <summary>
/// Helper class providing methods to apply sorting, pagination, and criteria filtering to IQueryable queries.
/// </summary>
public static class QueryHelper
{
    /// <summary>
    /// Retrieves an <see cref="Expression"/> that represents sorting by a specified property for entities of type TEntity.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to sort.</typeparam>
    /// <param name="sortBy">The name of the property to sort by.</param>
    /// <returns>An <see cref="Expression"/> that represents sorting by the specified property.</returns>
    private static Expression<Func<TEntity, object>> GetSortExpression<TEntity>(string sortBy)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "x");

        var properties = typeof(TEntity).GetProperties(
            BindingFlags.Public | BindingFlags.Instance);

        var defaultProperty = properties.FirstOrDefault();

        var property = properties.FirstOrDefault(prop =>
            string.Equals(prop.Name, sortBy, StringComparison.OrdinalIgnoreCase)) ?? defaultProperty;

        var propertyAccess = Expression.MakeMemberAccess(parameter, property!);

        return Expression.Lambda<Func<TEntity, object>>(
            Expression.Convert(propertyAccess, typeof(object)), parameter);
    }

    /// <summary>
    /// Applies sorting to an <see cref="IQueryable"/> query based on the provided sorting options.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity in the query.</typeparam>
    /// <param name="query">The IQueryable query to apply sorting to.</param>
    /// <param name="sorting">The sorting options specifying how to order the query results.</param>
    /// <returns>The sorted <see cref="IQueryable"/> query.</returns>
    public static IQueryable<TEntity> ApplySorting<TEntity>(this IQueryable<TEntity> query, ISortingOptions sorting)
    {
        if (string.IsNullOrEmpty(sorting.OrderBy))
            return query;

        var sortExpression = GetSortExpression<TEntity>(sorting.OrderBy);

        return sorting.OrderType.Equals(SortOrderType.Ascending)
            ? query.OrderBy(sortExpression)
            : query.OrderByDescending(sortExpression);
    }

    /// <summary>
    /// Applies pagination to an <see cref="IQueryable"/> query based on the provided pagination options.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity in the query.</typeparam>
    /// <param name="query">The IQueryable query to apply pagination to.</param>
    /// <param name="paginationOptions">The pagination options specifying page number and page size.</param>
    /// <returns>The <see cref="IQueryable"/> query with pagination applied.</returns>
    public static IQueryable<TEntity> ApplyPagination<TEntity>(this IQueryable<TEntity> query,
        IPaginationOptions paginationOptions)
    {
        if (paginationOptions.PageSize is null || paginationOptions.PageNumber is null)
            return query;

        switch (paginationOptions)
        {
            case { PageNumber: not null, PageSize: null }:
                throw new PageSizeMustHaveValueException();
            case { PageNumber: null, PageSize: not null }:
                throw new PageNumberMustHaveValueException();
            case { PageNumber: < 1 }:
                throw new PageNumberMustBePositiveException();
            case { PageSize: < 1 }:
                throw new PageSizeMustBePositiveException();
            default:
                query = query.Skip((paginationOptions.PageNumber!.Value - 1) * paginationOptions.PageSize!.Value)
                    .Take(paginationOptions.PageSize.Value);
                return query;
        }
    }

    /// <summary>
    /// Applies criteria filtering to an <see cref="IQueryable"/> query based on the provided list of criteria.
    /// </summary>
    /// <typeparam name="T">The type of entity in the query.</typeparam>
    /// <param name="query">The IQueryable query to apply criteria filtering to.</param>
    /// <param name="criteriaList">The list of criteria specifications defining the conditions for filtering.</param>
    /// <returns>The <see cref="IQueryable"/> query with criteria filtering applied.</returns>
    public static IQueryable<T> ApplyCriteria<T>(this IQueryable<T> query, IEnumerable<ICriteria<T>> criteriaList)
    {
        return criteriaList.Aggregate(query, (current, criteria) => current.Where(criteria.Criteria));
    }
}