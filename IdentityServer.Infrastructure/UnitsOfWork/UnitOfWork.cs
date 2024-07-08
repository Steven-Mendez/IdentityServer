using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Interfaces;
using IdentityServer.Infrastructure.DatabaseContexts;

namespace IdentityServer.Infrastructure.UnitsOfWork;

/// <summary>
///     Represents a unit of work in the context of IdentityServer, encapsulating various repositories
///     to manage transactions and changes as a single unit.
/// </summary>
/// <param name="context">The database context for IdentityServer.</param>
/// <param name="userRepository">The user repository to be used within this unit of work.</param>
public class UnitOfWork(IdentityServerContext context, IUserRepository userRepository) : IUnitOfWork
{
    /// <summary>
    ///     Gets the user repository associated with this unit of work.
    /// </summary>
    public IUserRepository UserRepository => userRepository;

    /// <summary>
    ///     Asynchronously saves all changes made in this context to the underlying database.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous save operation.</returns>
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}