using System.Linq.Expressions;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;

/// <summary>
/// Represents a criteria for filtering users based on their email.
/// </summary>
/// <param name="email">The email to filter users by. Null or empty value means no filtering.</param>
public class UserEmailCriteria(string? email) : ICriteria<User>
{
    /// <summary>
    /// Gets the LINQ expression that represents the criteria for filtering users by email.
    /// </summary>
    public Expression<Func<User, bool>> Criteria => user =>
        email.IsNullOrEmpty() || user.Email!.Contains(email!);
}