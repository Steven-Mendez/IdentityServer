using System.Linq.Expressions;
using System.Reflection;
using IdentityServer.Domain.Exceptions;
using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Domain.Helpers;

public static class QueryHelper
{
    private static Expression<Func<TEntity, object>> GetSortExpression<TEntity>(string sortBy)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "x");

        var property = typeof(TEntity).GetProperty(sortBy,
            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

        property ??=
            typeof(TEntity).GetProperty("Id", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

        var propertyAccess = Expression.MakeMemberAccess(parameter, property!);

        return Expression.Lambda<Func<TEntity, object>>(Expression.Convert(propertyAccess, typeof(object)), parameter);
    }

    public static IQueryable<TEntity> ApplySorting<TEntity>(this IQueryable<TEntity> query, ISorter sorting)
    {
        if (string.IsNullOrEmpty(sorting.SortBy) || string.IsNullOrEmpty(sorting.SortOrder))
            return query;

        var sortExpression = GetSortExpression<TEntity>(sorting.SortBy);

        query = sorting.SortOrder.ToLower().Equals("asc")
            ? query.OrderBy(sortExpression)
            : query.OrderByDescending(sortExpression);

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
                comparisonExpression = Expression.Call(Expression.Call(property, "ToLower", null), "Contains", null,
                    Expression.Call(value, "ToLower", null));
            else
                comparisonExpression = Expression.Equal(property, value);

            predicate = predicate == null
                ? Expression.Lambda<Func<T, bool>>(comparisonExpression, parameter)
                : Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(predicate.Body, comparisonExpression), parameter);
        }

        return predicate == null ? query : query.Where(predicate);
    }

    public static IQueryable<TEntity> ApplyPagination<TEntity>(this IQueryable<TEntity> query, IPagination pagination)
    {
        if (pagination.PageSize is null || pagination.PageNumber is null)
            return query;

        switch (pagination)
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
                query = query.Skip((pagination.PageNumber!.Value - 1) * pagination.PageSize!.Value)
                    .Take(pagination.PageSize.Value);
                return query;
        }
    }
}