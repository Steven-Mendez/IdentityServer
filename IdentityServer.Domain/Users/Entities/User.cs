using IdentityServer.Domain.Abstractions;

namespace IdentityServer.Domain.Users.Entities;

/// <summary>
/// Represents a user entity in the IdentityServer domain.
/// Inherits from <see cref="AuditEntity"/>.
/// </summary>
public class User : AuditEntity
{
    /// <summary>
    /// Gets or sets the external account identifier for the user.
    /// Nullable to indicate that the user might use a local login instead.
    /// </summary>
    public string? MicrosoftId { get; set; }
    
    /// <summary>
    /// Gets or sets the username of the user.
    /// Nullable to indicate that the username might not be provided if the user uses an external login.
    /// </summary>
    public string? UserName { get; set; }
    
    /// <summary>
    /// Gets or sets the email address of the user.
    /// Nullable to indicate that the email address might not be provided if the user uses an external login.
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Gets or sets the password for the user.
    /// Nullable to indicate that the password might not be provided if the user uses an external login.
    /// </summary>
    public string? Password { get; set; }
    
    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string FirstName { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string LastName { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the avatar URL for the user.
    /// Nullable to indicate that the avatar might not be provided.
    /// </summary>
    public string? Avatar { get; set; }
    
    /// <summary>
    /// Gets or sets a value indicating whether the user is blocked.
    /// </summary>
    public bool IsBlocked { get; set; }
}