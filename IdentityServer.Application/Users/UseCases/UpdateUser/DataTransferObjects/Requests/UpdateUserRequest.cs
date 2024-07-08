namespace IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;

/// <summary>
/// Represents the request data for updating a user.
/// </summary>
public class UpdateUserRequest
{
    /// <summary>
    /// Gets or sets the username of the user. This field is optional.
    /// </summary>
    /// <value>The username of the user.</value>
    public string? UserName { get; set; }

    /// <summary>
    /// Gets or sets the email of the user. This field is optional.
    /// </summary>
    /// <value>The email of the user.</value>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user. This field is optional.
    /// </summary>
    /// <value>The first name of the user.</value>
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user. This field is optional.
    /// </summary>
    /// <value>The last name of the user.</value>
    public string? LastName { get; set; }
}