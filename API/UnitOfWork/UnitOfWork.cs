using API.Contexts;

namespace API.UnitOfWork;

public class UnitOfWork(IdentityServerContext context)
{
    private readonly IdentityServerContext _context = context;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
