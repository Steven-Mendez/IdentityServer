namespace IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Requests;

/// <summary>
///     Represents a request to create a new user in the system.
/// </summary>
public class CreateUserRequest
{
    /// <summary>
    ///     Gets or sets the username of the new user.
    /// </summary>
    /// <value>The username of the user.</value>
    public string UserName { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the email of the new user.
    /// </summary>
    /// <value>The email address of the user.</value>
    public string Email { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the password for the new user.
    /// </summary>
    /// <value>The password of the user.</value>
    public string Password { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the first name of the new user.
    ///     Optional.
    /// </summary>
    /// <value>The first name of the user, or null if not provided.</value>
    public string? FirstName { get; set; }

    /// <summary>
    ///     Gets or sets the last name of the new user.
    ///     Optional.
    /// </summary>
    /// <value>The last name of the user, or null if not provided.</value>
    public string? LastName { get; set; }

    /// <summary>
    ///     Gets or sets the avatar URL of the new user.
    ///     Optional.
    /// </summary>
    /// <value>The URL of the user's avatar image, or null if not provided.</value>
    public string? Avatar { get; set; }
}