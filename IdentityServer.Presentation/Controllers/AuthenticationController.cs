using IdentityServer.Application.Authentication.Interfaces;
using IdentityServer.Application.Authentication.UseCase.Authenticate.DataTransferObjects.Requests;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    private readonly IAuthenticationService _authenticationService = authenticationService;

    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest request)
    {
        var isAuthenticated = await _authenticationService.Authenticate(request);
        return Ok(isAuthenticated);
    }
}