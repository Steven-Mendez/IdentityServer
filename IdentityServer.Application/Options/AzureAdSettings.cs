namespace IdentityServer.Application.Options;

/// <summary>
/// Represents the settings required for Azure Active Directory authentication.
/// </summary>
public class AzureAdSettings
{
    /// <summary>
    /// Gets the Azure AD client ID.
    /// </summary>
    /// <value>The client ID.</value>
    public string ClientId { get; init; } = null!;
    
    /// <summary>
    /// Gets the Azure AD tenant ID.
    /// </summary>
    /// <value>The tenant ID.</value>
    public string TenantId { get; init; } = null!;
    
    /// <summary>
    /// Gets the Azure AD client secret.
    /// </summary>
    /// <value>The client secret.</value>
    public string ClientSecret { get; init; } = null!;
    
    /// <summary>
    /// Gets the redirect URL used for Azure AD authentication responses.
    /// </summary>
    /// <value>The redirect URL.</value>
    public string RedirectUrl { get; init; } = null!;
}