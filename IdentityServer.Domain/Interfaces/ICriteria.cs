using System.Linq.Expressions;

namespace IdentityServer.Domain.Interfaces;

public interface ICriteria<TEntity>
{
    Expression<Func<TEntity, bool>> Criteria { get; }
}