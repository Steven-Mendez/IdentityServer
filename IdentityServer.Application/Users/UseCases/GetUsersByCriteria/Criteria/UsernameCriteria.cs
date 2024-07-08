using System.Linq.Expressions;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;

/// <summary>
///     Represents a criteria for filtering users based on their username.
/// </summary>
/// <param name="userName">The username to filter users by. Null or empty value means no filtering.</param>
public class UsernameCriteria(string? userName) : ICriteria<User>
{
    /// <summary>
    ///     Gets the LINQ expression that represents the criteria for filtering users by username.
    /// </summary>
    public Expression<Func<User, bool>> Criteria => user =>
        userName.IsNullOrEmpty() || user.UserName!.Contains(userName!);
}