using IdentityServer.Application.Authentication.Interfaces;
using IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Requests;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(ILocalAuthenticationService localAuthenticationService, IAzureAuthenticationService azureAuthenticationService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] LocalAuthenticationRequest request)
    {
        var isAuthenticated = await localAuthenticationService.Authenticate(request);
        return Ok(isAuthenticated);
    }

    [HttpGet("Oauth2.0/azure-ad/redirect")]
    public IActionResult Get()
    {
        return Redirect(azureAuthenticationService.Redirect());
    }

    [HttpGet("Oauth2.0/azure-ad/callback")]
    public IActionResult GetCallback([FromQuery] string code)
    {
        var url = azureAuthenticationService.Callback("TODO:GenerateJwtForOauth");
        return Ok(new { url, code });
    }
}