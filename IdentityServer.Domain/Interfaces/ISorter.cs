namespace IdentityServer.Domain.Interfaces;

public interface ISorter
{
    string? SortBy { get; set; }
    string? SortOrder { get; set; }
}