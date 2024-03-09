using IdentityServer.Domain.Interfaces;
using System.Linq.Expressions;

namespace IdentityServer.Domain.Helpers;

public static class QueryHelper
{
    public static IQueryable<TEntity> ApplyPagination<TEntity>(this IQueryable<TEntity> query, IPagination pagination)
    {
        query = query.Skip((pagination.Page - 1) * pagination.PageSize)
                     .Take(pagination.PageSize);
        return query;
    }

    public static IQueryable<TEntity> ApplySorting<TEntity>(this IQueryable<TEntity> query, ISorter sorting)
    {
        if (!string.IsNullOrEmpty(sorting.SortBy) && !string.IsNullOrEmpty(sorting.SortOrder))
        {
            var sortExpression = ExpressionHelper.GetSortExpression<TEntity>(sorting.SortBy);

            if (sorting.SortOrder.ToLower().Equals("asc"))
                query = query.OrderBy(sortExpression);
            else
                query = query.OrderByDescending(sortExpression);
        }
        return query;
    }

    public static IQueryable<T> ApplyFilters<T, TFilter>(this IQueryable<T> query, TFilter filter)
    {
        var parameter = Expression.Parameter(typeof(T), "x");

        Expression<Func<T, bool>>? predicate = null;

        foreach (var propertyInfo in typeof(TFilter).GetProperties())
        {
            var filterValue = propertyInfo.GetValue(filter);

            if (filterValue == null)
                continue;

            var entityProperty = typeof(T).GetProperty(propertyInfo.Name);

            if (entityProperty == null)
                continue;

            var property = Expression.Property(parameter, entityProperty);

            var value = Expression.Constant(filterValue);

            Expression comparisonExpression;

            if (entityProperty.PropertyType == typeof(string))
                comparisonExpression = Expression.Call(Expression.Call(property, "ToLower", null), "Contains", null, Expression.Call(value, "ToLower", null));
            else
                comparisonExpression = Expression.Equal(property, value);

            predicate = predicate == null
                ? Expression.Lambda<Func<T, bool>>(comparisonExpression, parameter)
                : Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(predicate.Body, comparisonExpression), parameter);
        }

        if (predicate == null)
            return query;

        return query.Where(predicate);
    }
}
