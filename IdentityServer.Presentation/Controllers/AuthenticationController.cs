using IdentityServer.Application.Authentication.Interfaces;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Requests;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Presentation.Controllers;

/// <summary>
///     Handles authentication requests, including local and Azure AD OAuth2.0 flows.
/// </summary>
/// <param name="localAuthenticationService">The service for handling local authentication.</param>
/// <param name="azureAuthenticationService">The service for handling Azure AD authentication.</param>
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(
    ILocalAuthenticationService localAuthenticationService,
    IAzureAuthenticationService azureAuthenticationService) : ControllerBase
{
    /// <summary>
    ///     Authenticates a user using local authentication.
    /// </summary>
    /// <param name="request">The authentication request containing user credentials.</param>
    /// <returns>An <see cref="IActionResult" /> indicating the result of the authentication process.</returns>
    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] LocalAuthenticationRequest request)
    {
        var isAuthenticated = await localAuthenticationService.Authenticate(request);
        return Ok(isAuthenticated);
    }

    /// <summary>
    ///     Redirects to Azure AD for OAuth2.0 authentication.
    /// </summary>
    /// <returns>A redirect action to the Azure AD login page.</returns>
    [HttpGet("Oauth2.0/azure-ad/redirect")]
    public IActionResult Get()
    {
        return Redirect(azureAuthenticationService.Redirect());
    }

    /// <summary>
    ///     Handles the callback from Azure AD after OAuth2.0 authentication.
    /// </summary>
    /// <param name="code">The authorization code returned by Azure AD.</param>
    /// <returns>An <see cref="IActionResult" /> containing the callback URL and the authorization code.</returns>
    [HttpGet("Oauth2.0/azure-ad/callback")]
    public async Task<IActionResult> GetCallback([FromQuery] string code)
    {
        var url = await azureAuthenticationService.Callback(code);
        return Ok(new { url, code });
    }
}