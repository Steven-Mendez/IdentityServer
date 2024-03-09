using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Implementations;

public class Pagination : IPagination
{
    public int Page { get; init; }
    public int PageSize { get; init; }
}
