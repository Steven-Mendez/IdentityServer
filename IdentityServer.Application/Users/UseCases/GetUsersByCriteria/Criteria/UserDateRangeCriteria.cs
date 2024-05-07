using System.Linq.Expressions;
using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.Criteria;

public class UserDateRangeCriteria(DateTime? startDate, DateTime? endDate) : ICriteria<User>
{
    public Expression<Func<User, bool>> Criteria => user =>
        (startDate == null || user.CreatedAt >= startDate) &&
        (endDate == null || user.CreatedAt <= endDate);
}