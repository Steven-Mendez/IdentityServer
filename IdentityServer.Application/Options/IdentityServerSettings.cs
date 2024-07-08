namespace IdentityServer.Application.Options;

/// <summary>
///     Represents the settings for the IdentityServer application.
/// </summary>
public class IdentityServerSettings
{
    /// <summary>
    ///     Gets the URL of the IdentityServer application.
    /// </summary>
    /// <value>The IdentityServer application URL.</value>
    public string Url { get; init; } = null!;
}