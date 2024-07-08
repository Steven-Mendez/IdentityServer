namespace IdentityServer.Application.Options;

/// <summary>
///     Represents the settings for JSON Web Tokens (JWT) used by the IdentityServer application.
/// </summary>
public class JsonWebTokenSettings
{
    /// <summary>
    ///     Gets the issuer of the JWT.
    /// </summary>
    /// <value>The issuer of the token.</value>
    public string Issuer { get; init; } = null!;

    /// <summary>
    ///     Gets the audience for the JWT.
    /// </summary>
    /// <value>The audience of the token.</value>
    public string Audience { get; init; } = null!;

    /// <summary>
    ///     Gets the signing key used to sign the JWT.
    /// </summary>
    /// <value>The signing key as a string.</value>
    public string SigningKey { get; init; } = null!;

    /// <summary>
    ///     Gets the expiration time of the JWT in minutes.
    /// </summary>
    /// <value>The expiration time in minutes.</value>
    public int ExpirationMinutes { get; init; }
}