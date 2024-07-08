namespace IdentityServer.Application.Options;

/// <summary>
/// Represents the settings for the frontend application.
/// </summary>
public class FrontendSettings
{
    /// <summary>
    /// Gets the URL of the frontend application.
    /// </summary>
    /// <value>The frontend application URL.</value>
    public string Url { get; init; } = null!;
}