using System.Linq.Expressions;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;

/// <summary>
///     Represents a criteria for filtering users based on their first name.
/// </summary>
/// <param name="firstName">The first name to filter users by. Null or empty value means no filtering.</param>
public class UserFirstNameCriteria(string? firstName) : ICriteria<User>
{
    /// <summary>
    ///     Gets the LINQ expression that represents the criteria for filtering users by first name.
    /// </summary>
    public Expression<Func<User, bool>> Criteria => user =>
        firstName.IsNullOrEmpty() || user.FirstName.Contains(firstName!);
}