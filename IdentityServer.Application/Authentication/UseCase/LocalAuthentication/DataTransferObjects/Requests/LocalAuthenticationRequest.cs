namespace IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Requests;

/// <summary>
///     Represents a request for local authentication.
/// </summary>
public class LocalAuthenticationRequest
{
    /// <summary>
    ///     Gets or sets the login identifier for the user.
    /// </summary>
    /// <value>The user's login identifier.</value>
    public string Login { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the password for the user.
    /// </summary>
    /// <value>The user's password.</value>
    public string Password { get; set; } = null!;
}