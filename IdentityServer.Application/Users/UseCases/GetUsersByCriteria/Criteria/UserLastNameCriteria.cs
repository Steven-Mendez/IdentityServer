using System.Linq.Expressions;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;

public class UserLastNameCriteria(string? lastName) : ICriteria<User>
{
    public Expression<Func<User, bool>> Criteria => user =>
        lastName.IsNullOrEmpty() || user.LastName!.Contains(lastName!);
}