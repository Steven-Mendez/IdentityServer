using System.Linq.Expressions;
using System.Reflection;
using IdentityServer.Domain.Enums;
using IdentityServer.Domain.Exceptions;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Domain.Helpers;

public static class QueryHelper
{
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

    public static IQueryable<TEntity> ApplySorting<TEntity>(this IQueryable<TEntity> query, ISortingOptions sorting)
    {
        if (string.IsNullOrEmpty(sorting.OrderBy))
            return query;

        var sortExpression = GetSortExpression<TEntity>(sorting.OrderBy);

        return sorting.OrderType.Equals(SortOrderType.Ascending)
            ? query.OrderBy(sortExpression)
            : query.OrderByDescending(sortExpression);
    }

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

    public static IQueryable<T> ApplyCriteria<T>(this IQueryable<T> query, IEnumerable<ICriteria<T>> criteriaList)
    {
        return criteriaList.Aggregate(query, (current, criteria) => current.Where(criteria.Criteria));
    }
}