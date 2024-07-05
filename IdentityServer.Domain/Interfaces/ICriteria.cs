using System.Linq.Expressions;

namespace IdentityServer.Domain.Interfaces;

/// <summary>
/// Represents a criteria interface for querying entities of type TEntity.
/// </summary>
/// <typeparam name="TEntity">The type of entity that the criteria applies to.</typeparam>
public interface ICriteria<TEntity>
{
    /// <summary>
    /// Gets the criteria expression that defines the conditions for querying entities.
    /// </summary>
    Expression<Func<TEntity, bool>> Criteria { get; }
}