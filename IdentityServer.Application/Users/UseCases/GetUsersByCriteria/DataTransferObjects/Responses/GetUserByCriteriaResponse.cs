namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;

/// <summary>
///     Represents the response data for a user retrieval request based on specified criteria.
/// </summary>
public class GetUserByCriteriaResponse
{
    /// <summary>
    ///     Gets the unique identifier of the user.
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
    ///     Gets a value indicating whether the user is blocked.
    /// </summary>
    public bool IsBlocked { get; init; }

    /// <summary>
    ///     Gets the date and time when the user was created.
    /// </summary>
    public DateTime CreatedAt { get; init; }
}