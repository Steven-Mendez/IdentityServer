using IdentityServer.Domain.Abstractions;

namespace IdentityServer.Domain.Users.Entities;

public class User : AuditEntity
{
    public string? UserName { get; set; }
    public string Email { get; set; } = null!;
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Avatar { get; set; }
    public bool IsBlocked { get; set; }
}