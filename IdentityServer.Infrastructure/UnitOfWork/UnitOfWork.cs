using IdentityServer.Domain.Interfaces;
using IdentityServer.Infrastructure.Data;

namespace IdentityServer.Infrastructure.UnitOfWork;

public class UnitOfWork(IdentityServerContext context) : IUnitOfWork
{
    private readonly IdentityServerContext _context = context;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
