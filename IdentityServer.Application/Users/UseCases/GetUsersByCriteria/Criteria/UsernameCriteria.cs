using System.Linq.Expressions;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;

public class UsernameCriteria(string? userName) : ICriteria<User>
{
    public Expression<Func<User, bool>> Criteria => user =>
        userName.IsNullOrEmpty() || user.UserName!.Contains(userName!);
}