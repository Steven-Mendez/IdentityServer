namespace IdentityServer.Application.Users.UseCases.GetUserById.DataTransferObjects.Response;

/// <summary>
///     Represents the response data for a request to get a user by their unique identifier.
/// </summary>
public class GetUserByIdResponse
{
    /// <summary>
    ///     Gets the unique identifier for the user.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    ///     Gets the username of the user.
    /// </summary>
    public string UserName { get; init; } = null!;

    /// <summary>
    ///     Gets the email address of the user.
    /// </summary>
    public string Email { get; init; } = null!;

    /// <summary>
    ///     Gets the first name of the user.
    /// </summary>
    public string FirstName { get; init; } = null!;

    /// <summary>
    ///     Gets the last name of the user.
    /// </summary>
    public string LastName { get; init; } = null!;

    /// <summary>
    ///     Gets the avatar URL of the user.
    /// </summary>
    public string Avatar { get; init; } = null!;

    /// <summary>
    ///     Indicates whether the user is blocked.
    /// </summary>
    public bool IsBlocked { get; init; }
}