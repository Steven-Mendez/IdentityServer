using System.Linq.Expressions;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;

/// <summary>
/// Represents a criteria for filtering users based on their last name.
/// </summary>
/// <param name="lastName">The last name to filter users by. Null or empty value means no filtering.</param>
public class UserLastNameCriteria(string? lastName) : ICriteria<User>
{
    /// <summary>
    /// Gets the LINQ expression that represents the criteria for filtering users by last name.
    /// </summary>
    public Expression<Func<User, bool>> Criteria => user =>
        lastName.IsNullOrEmpty() || user.LastName!.Contains(lastName!);
}