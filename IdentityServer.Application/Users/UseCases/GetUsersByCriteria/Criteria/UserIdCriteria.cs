using System.Linq.Expressions;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;

public class UserIdCriteria(Guid? id) : ICriteria<User>
{
    public Expression<Func<User, bool>> Criteria => user => !id.HasValue || user.Id.Equals(id);
}