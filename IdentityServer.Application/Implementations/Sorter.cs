using IdentityServer.Domain.Interfaces;

namespace IdentityServer.Application.Implementations;

public class Sorter : ISorter
{
    public string? SortBy { get; set; }
    public string? SortOrder { get; set; }
}
