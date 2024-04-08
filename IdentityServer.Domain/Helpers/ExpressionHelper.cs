using System.Linq.Expressions;
using System.Reflection;

namespace IdentityServer.Domain.Helpers;

public static class ExpressionHelper
{
    public static Expression<Func<TSource, TKey>> GetExpression<TSource, TKey>(
        Expression<Func<TSource, TKey>> keySelector)
    {
        return keySelector;
    }

    public static Expression<Func<TEntity, object>> GetSortExpression<TEntity>(string sortBy)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "x");

        var property = typeof(TEntity).GetProperty(sortBy,
            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

        property ??=
            typeof(TEntity).GetProperty("Id", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

        var propertyAccess = Expression.MakeMemberAccess(parameter, property!);

        return Expression.Lambda<Func<TEntity, object>>(Expression.Convert(propertyAccess, typeof(object)), parameter);
    }
}