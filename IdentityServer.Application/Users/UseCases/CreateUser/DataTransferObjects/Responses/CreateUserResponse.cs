namespace IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Responses;

/// <summary>
/// Represents the response returned after creating a new user.
/// </summary>
public class CreateUserResponse
{
    /// <summary>
    /// Gets the unique identifier for the user.
    /// </summary>
    /// <value>The user's unique identifier.</value>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Gets the username of the created user.
    /// </summary>
    /// <value>The username of the user.</value>
    public string UserName { get; init; } = null!;
    
    /// <summary>
    /// Gets the email of the created user.
    /// </summary>
    /// <value>The email address of the user.</value>
    public string Email { get; init; } = null!;
    
    /// <summary>
    /// Gets the first name of the created user. Optional.
    /// </summary>
    /// <value>The first name of the user, or null if not provided.</value>
    public string? FirstName { get; init; }
    
    /// <summary>
    /// Gets the last name of the created user. Optional.
    /// </summary>
    /// <value>The last name of the user, or null if not provided.</value>
    public string? LastName { get; init; }
    
    /// <summary>
    /// Gets the avatar URL of the created user. Optional.
    /// </summary>
    /// <value>The URL of the user's avatar image, or null if not provided.</value>
    public string? Avatar { get; init; }
    
    /// <summary>
    /// Indicates whether the user is blocked.
    /// </summary>
    /// <value>True if the user is blocked, otherwise false.</value>
    public bool IsBlocked { get; init; }
}