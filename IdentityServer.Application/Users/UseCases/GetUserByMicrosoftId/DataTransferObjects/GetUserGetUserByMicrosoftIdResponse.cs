namespace IdentityServer.Application.Users.UseCases.GetUserByMicrosoftId.DataTransferObjects;

/// <summary>
///     Represents the response data for a request to get a user by their Microsoft ID.
/// </summary>
public class GetUserGetUserByMicrosoftIdResponse
{
    /// <summary>
    ///     Gets the unique identifier for the user.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    ///     Gets the user's username.
    /// </summary>
    public string UserName { get; init; } = null!;

    /// <summary>
    ///     Gets the user's email address.
    /// </summary>
    public string Email { get; init; } = null!;

    /// <summary>
    ///     Gets the user's first name.
    /// </summary>
    public string FirstName { get; init; } = null!;

    /// <summary>
    ///     Gets the user's last name.
    /// </summary>
    public string LastName { get; init; } = null!;

    /// <summary>
    ///     Gets the URL to the user's avatar image.
    /// </summary>
    public string Avatar { get; init; } = null!;

    /// <summary>
    ///     Indicates whether the user is currently blocked.
    /// </summary>
    public bool IsBlocked { get; init; }
}