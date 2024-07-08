using IdentityServer.Domain.Users.Interfaces;

namespace IdentityServer.Domain.Interfaces;

/// <summary>
///     Represents a unit of work interface for managing repositories and saving changes asynchronously.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    ///     Gets the repository for managing user entities.
    /// </summary>
    IUserRepository UserRepository { get; }

    /// <summary>
    ///     Asynchronously saves all changes made in this unit of work to the underlying storage.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous save operation.</returns>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}