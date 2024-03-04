﻿using IdentityServer.Application.Users.Interfaces;
using IdentityServer.Application.Users.UseCases.CreateUser.DTOS.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DTOS.Responses;
using IdentityServer.Application.Users.UseCases.GetAllUsers.DTO.Responses;
using IdentityServer.Application.Users.UseCases.GetUserById.DTO.Response;
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
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        var response = new Response<IEnumerable<GetAllUsersResponse>>(users);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Response<GetUserByIdResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        var response = new Response<GetUserByIdResponse>(user);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Response<CreateUserResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
    {
        var user = await _userService.AddUserAsync(createUserRequest);
        var response = new Response<CreateUserResponse>(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }
}
