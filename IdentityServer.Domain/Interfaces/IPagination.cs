namespace IdentityServer.Domain.Interfaces;

public interface IPagination
{
    public int? PageNumber { get; }
    public int? PageSize { get; }
}