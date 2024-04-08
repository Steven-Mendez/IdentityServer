using IdentityServer.Domain.Interfaces;
using IdentityServer.Domain.Users.Interfaces;
using IdentityServer.Infrastructure.DatabaseContexts;

namespace IdentityServer.Infrastructure.UnitsOfWork;

public class UnitOfWork(IdentityServerContext context, IUserRepository userRepository) : IUnitOfWork
{
    private readonly IdentityServerContext _context = context;
    public IUserRepository UserRepository => userRepository;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}