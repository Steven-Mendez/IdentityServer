using IdentityServer.Domain.Abstractions;

namespace IdentityServer.Domain.Users.Entities;

public class User : AuditEntity
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Avatar { get; set; }
    public bool IsBlocked { get; set; }
}