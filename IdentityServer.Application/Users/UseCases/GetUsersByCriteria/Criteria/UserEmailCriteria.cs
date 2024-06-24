using System.Linq.Expressions;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;

public class UserEmailCriteria(string? email) : ICriteria<User>
{
    public Expression<Func<User, bool>> Criteria => user =>
        email.IsNullOrEmpty() || user.Email!.Contains(email!);
}