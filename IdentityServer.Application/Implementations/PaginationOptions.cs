using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Implementations;

public class PaginationOptions( int? pageSize, int? pageNumber) : IPaginationOptions
{
    public int? PageNumber { get; } = pageNumber;
    public int? PageSize { get; } = pageSize;
}