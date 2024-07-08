using System.Linq.Expressions;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;

/// <summary>
/// Represents a criteria for filtering users based on their unique identifier.
/// </summary>
/// <param name="id">The unique identifier to filter users by. Null value means no filtering.</param>
public class UserIdCriteria(Guid? id) : ICriteria<User>
{
    /// <summary>
    /// Gets or sets the unique identifier used for filtering.
    /// </summary>
    public Expression<Func<User, bool>> Criteria => user => !id.HasValue || user.Id.Equals(id);
}