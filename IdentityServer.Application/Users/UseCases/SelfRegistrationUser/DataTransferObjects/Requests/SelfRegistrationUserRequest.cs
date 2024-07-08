namespace IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Requests;

/// <summary>
///     Represents a request for self-registering a user in the system.
/// </summary>
public class SelfRegistrationUserRequest
{
    /// <summary>
    ///     Gets or sets the username of the user.
    /// </summary>
    /// <value>The username of the user.</value>
    public string UserName { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the email of the user.
    /// </summary>
    /// <value>The email of the user.</value>
    public string Email { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the password of the user.
    /// </summary>
    /// <value>The password of the user.</value>
    public string Password { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the first name of the user.
    /// </summary>
    /// <value>The first name of the user.</value>
    public string FirstName { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the last name of the user.
    /// </summary>
    /// <value>The last name of the user.</value>
    public string LastName { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the avatar of the user. This is optional.
    /// </summary>
    /// <value>The avatar of the user, if any.</value>
    public string? Avatar { get; set; }
}