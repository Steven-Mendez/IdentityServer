namespace IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Responses;

/// <summary>
///     Represents a request for self-registering a user in the system.
///     This request includes all necessary information for creating a new user account,
///     such as username, email, password, first name, last name, and optionally an avatar.
/// </summary>
public class SelfRegistrationUserResponse
{
    /// <summary>
    ///     Gets the unique identifier of the user.
    /// </summary>
    /// <value>The unique identifier of the user.</value>
    public Guid Id { get; init; }

    /// <summary>
    ///     Gets the username of the user.
    /// </summary>
    /// <value>The username of the user.</value>
    public string UserName { get; init; } = null!;

    /// <summary>
    ///     Gets the email of the user.
    /// </summary>
    /// <value>The email of the user.</value>
    public string Email { get; init; } = null!;

    /// <summary>
    ///     Gets the first name of the user.
    /// </summary>
    /// <value>The first name of the user.</value>
    public string FirstName { get; init; } = null!;

    /// <summary>
    ///     Gets the last name of the user.
    /// </summary>
    /// <value>The last name of the user.</value>
    public string LastName { get; init; } = null!;

    /// <summary>
    ///     Gets the avatar of the user. This is optional.
    /// </summary>
    /// <value>The avatar of the user, if any.</value>
    public string? Avatar { get; init; }
}