using IdentityServer.Domain.Abstractions;

namespace IdentityServer.Domain.Interfaces;

/// <summary>
///     Represents a generic repository interface for basic CRUD operations on entities of type T.
///     Requires entities to inherit from <see cref="BaseEntity" />.
/// </summary>
/// <typeparam name="T">The type of entity that the repository operates on, inheriting from <see cref="BaseEntity" />.</typeparam>
public interface IRepository<T> where T : BaseEntity
{
    /// <summary>
    ///     Asynchronously retrieves all entities of type T.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, returning an enumerable collection of entities.</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    ///     Asynchronously retrieves entities of type T based on specified criteria defined by an
    ///     <see cref="ISpecification{T}" />.
    /// </summary>
    /// <param name="specification">The specification defining the criteria for filtering entities.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation, returning a tuple containing filtered entities and total
    ///     record count.
    /// </returns>
    Task<(IEnumerable<T> Items, int TotalRecords)> GetByCriteriaAsync(ISpecification<T> specification);

    /// <summary>
    ///     Asynchronously retrieves an entity of type T by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation, returning the entity with the specified identifier.</returns>
    Task<T> GetByIdAsync(Guid id);

    /// <summary>
    ///     Asynchronously adds a new entity of type T to the repository.
    /// </summary>
    /// <param name="entity">The entity of type T to add.</param>
    /// <returns>A task that represents the asynchronous operation, returning the added entity.</returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    ///     Asynchronously updates an existing entity of type T in the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to update.</param>
    /// <param name="entity">The updated entity of type T.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateAsync(Guid id, T entity);

    /// <summary>
    ///     Asynchronously deletes an entity of type T from the repository by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteAsync(Guid id);
}