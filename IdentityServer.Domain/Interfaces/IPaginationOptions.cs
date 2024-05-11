namespace IdentityServer.Domain.Interfaces;

public interface IPaginationOptions
{
    public int? PageNumber { get; }
    public int? PageSize { get; }
}