using System.Linq.Expressions;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;

public class UserIsBlockedCriteria(bool? isBlocked) : ICriteria<User>
{
    public Expression<Func<User, bool>> Criteria => user => !isBlocked.HasValue || user.IsBlocked.Equals(isBlocked);
}