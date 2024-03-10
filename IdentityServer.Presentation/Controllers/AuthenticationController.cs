using IdentityServer.Application.Authentiacion.Interfaces;
using IdentityServer.Application.Authentiacion.UseCase.Authenticate.DTOS.Requests;
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
