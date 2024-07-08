namespace IdentityServer.Application.Users.UseCases.SoftDeleteUser.DataTransferObjects.Responses;

/// <summary>
///     Represents the response returned after a user is soft-deleted in the system.
///     This response includes the unique identifier of the user, their username, email,
///     optional first name, last name, and avatar, along with a flag indicating whether the user is deleted.
/// </summary>
public class SoftDeleteUserResponse
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
    ///     Gets the first name of the user. This is optional.
    /// </summary>
    /// <value>The first name of the user, if any.</value>
    public string? FirstName { get; init; }

    /// <summary>
    ///     Gets the last name of the user. This is optional.
    /// </summary>
    /// <value>The last name of the user, if any.</value>
    public string? LastName { get; init; }

    /// <summary>
    ///     Gets the avatar of the user. This is optional.
    /// </summary>
    /// <value>The avatar of the user, if any.</value>
    public string? Avatar { get; init; }

    /// <summary>
    ///     Gets a value indicating whether the user is deleted.
    /// </summary>
    /// <value><c>true</c> if the user is deleted; otherwise, <c>false</c>.</value>
    public bool IsDeleted { get; init; }
}