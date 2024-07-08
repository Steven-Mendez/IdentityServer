using System.Linq.Expressions;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;

/// <summary>
/// Represents a criteria for filtering users based on their blocked status.
/// </summary>
/// <param name="isBlocked">The blocked status to filter users by. Null value means no filtering.</param>
public class UserIsBlockedCriteria(bool? isBlocked) : ICriteria<User>
{
    /// <summary>
    /// Gets or sets the blocked status used for filtering.
    /// </summary>
    public Expression<Func<User, bool>> Criteria => user => !isBlocked.HasValue || user.IsBlocked.Equals(isBlocked);
}