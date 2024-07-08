namespace IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Responses;

/// <summary>
/// Represents the response from a local authentication request.
/// </summary>
public class LocalAuthenticationResponse
{
    /// <summary>
    /// Gets or sets the token generated after successful authentication.
    /// </summary>
    /// <value>The authentication token.</value>
    public string Token { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the refresh token that can be used to generate a new authentication token.
    /// </summary>
    /// <value>The refresh token.</value>
    public string RefreshToken { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the expiration date and time of the token.
    /// </summary>
    /// <value>The expiration date and time of the token.</value>
    public DateTime Expires { get; set; }
    
    /// <summary>
    /// Gets or sets the type of the token, typically "Bearer".
    /// </summary>
    /// <value>The type of the token.</value>
    public string TokenType { get; set; } = null!;
}