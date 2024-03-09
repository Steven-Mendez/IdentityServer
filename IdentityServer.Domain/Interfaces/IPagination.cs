namespace IdentityServer.Domain.Interfaces;

public interface IPagination
{
    public int Page { get; init; }
    public int PageSize { get; init; }
}