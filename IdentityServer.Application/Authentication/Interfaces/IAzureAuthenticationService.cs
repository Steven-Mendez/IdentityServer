namespace IdentityServer.Application.Authentication.Interfaces;

/// <summary>
/// Defines the contract for Azure authentication services.
/// </summary>
public interface IAzureAuthenticationService
{
    /// <summary>
    /// Initiates the authentication process by redirecting the user to the Azure login page.
    /// </summary>
    /// <returns>A URL to redirect the user to for Azure authentication.</returns>
    string Redirect();
    
    /// <summary>
    /// Handles the callback from Azure after the user has authenticated.
    /// </summary>
    /// <param name="code">The authorization code returned by Azure.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the authentication token.</returns>
    Task<string> Callback(string code);
}