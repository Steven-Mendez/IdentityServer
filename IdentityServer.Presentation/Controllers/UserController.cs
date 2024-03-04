using IdentityServer.Application.Users.Interfaces;
using IdentityServer.Application.Users.UseCases.GetAllUsers.DataTransferObjects.Responses;
using IdentityServer.Presentation.Responses;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Presentation.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    [ProducesResponseType(typeof(Response<IEnumerable<GetAllUsersResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var users = await _userService.GetAllUsersAsync();
        var response = new Response<IEnumerable<GetAllUsersResponse>>(users);
        return Ok(response);
    }
}
