namespace IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Responses;

/// <summary>
///     Represents the response data for updating a user.
/// </summary>
public class UpdateUserResponse
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
    ///     Gets the first name of the user. This field is optional.
    /// </summary>
    /// <value>The first name of the user, if provided.</value>
    public string? FirstName { get; init; }

    /// <summary>
    ///     Gets the last name of the user. This field is optional.
    /// </summary>
    /// <value>The last name of the user, if provided.</value>
    public string? LastName { get; init; }

    /// <summary>
    ///     Gets the avatar of the user. This field is optional.
    /// </summary>
    /// <value>The avatar of the user, if provided.</value>
    public string? Avatar { get; init; }

    /// <summary>
    ///     Gets a value indicating whether the user is blocked.
    /// </summary>
    /// <value><c>true</c> if the user is blocked; otherwise, <c>false</c>.</value>
    public bool IsBlocked { get; init; }
}