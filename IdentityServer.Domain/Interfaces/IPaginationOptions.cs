namespace IdentityServer.Domain.Interfaces;

/// <summary>
/// Represents pagination options for querying data.
/// </summary>
public interface IPaginationOptions
{
    /// <summary>
    /// Gets the page number for pagination.
    /// </summary>
    public int? PageNumber { get; }
    
    /// <summary>
    /// Gets the page size for pagination.
    /// </summary>
    public int? PageSize { get; }
}