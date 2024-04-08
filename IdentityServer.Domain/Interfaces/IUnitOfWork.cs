using IdentityServer.Domain.Users.Interfaces;

namespace IdentityServer.Domain.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}