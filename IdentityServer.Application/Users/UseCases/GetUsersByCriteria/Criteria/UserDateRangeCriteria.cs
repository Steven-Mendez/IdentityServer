using System.Linq.Expressions;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;

/// <summary>
/// Represents a criteria for filtering users based on a date range.
/// </summary>
/// <param name="startDate">The start date of the range. Users created on or after this date are included. Null means no lower limit.</param>
/// <param name="endDate">The end date of the range. Users created on or before this date are included. Null means no upper limit.</param>
public class UserDateRangeCriteria(DateTime? startDate, DateTime? endDate) : ICriteria<User>
{
    /// <summary>
    /// Gets the LINQ expression that represents the criteria.
    /// </summary>
    public Expression<Func<User, bool>> Criteria => user =>
        (startDate == null || user.CreatedAt >= startDate) &&
        (endDate == null || user.CreatedAt <= endDate);
}