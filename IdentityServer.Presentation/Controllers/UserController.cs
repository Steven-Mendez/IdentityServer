using IdentityServer.Application.Users.Interfaces;
using IdentityServer.Domain.Users.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Presentation.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        throw new BlockedUserException();
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }
}
