namespace IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Requests;

/// <summary>
///     Represents a request for filtering users based on various criteria.
/// </summary>
public class GetUserByCriteriaFilterRequest
{
    /// <summary>
    ///     Gets or sets the unique identifier for filtering users.
    /// </summary>
    public Guid? Id { get; set; }

    /// <summary>
    ///     Gets or sets the start date for filtering users based on creation or modification date.
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    ///     Gets or sets the end date for filtering users based on creation or modification date.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    ///     Gets or sets the username for filtering users.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    ///     Gets or sets the email for filtering users.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    ///     Gets or sets the first name for filtering users.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    ///     Gets or sets the last name for filtering users.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    ///     Gets or sets the blocked status for filtering users.
    /// </summary>
    public bool? IsBlocked { get; set; }
}