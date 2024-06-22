using IdentityServer.Domain.Abstractions;

namespace IdentityServer.Domain.Users.Entities;

public class User : AuditEntity
{
    public Guid? MicrosoftId { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Avatar { get; set; }
    public bool IsBlocked { get; set; }
}