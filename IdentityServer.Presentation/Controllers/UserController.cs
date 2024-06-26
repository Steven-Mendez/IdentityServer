﻿using IdentityServer.Application.Commons.DataTransferObjects.Requests;
using IdentityServer.Application.Users.Interfaces;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.GetUserById.DataTransferObjects.Response;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Responses;
using IdentityServer.Presentation.Responses;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService, IHttpContextAccessor httpContextAccessor) : ControllerBase
{
    private readonly string _baseUrl =
        $"{httpContextAccessor.HttpContext!.Request.Scheme}://{httpContextAccessor.HttpContext!.Request.Host}";

    [HttpGet]
    [ProducesResponseType(typeof(PagedResponse<GetUserByCriteriaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUsers([FromQuery] GetUserByCriteriaFilterRequest byCriteriaFilterRequest,
        [FromQuery] SortingOptionsRequest sortingOptions, [FromQuery] PaginationOptionsRequest paginationOptions)
    {
        var endPointUrl =
            $"{_baseUrl}/{ControllerContext.ActionDescriptor.AttributeRouteInfo!.Template}";
        var request = new GetUsersByCriteriaRequest(byCriteriaFilterRequest, sortingOptions, paginationOptions);
        var pagedUsers = await userService.GetUsersByCriteriaAsync(request);
        var pagedResponse = ApiResponse.CreatePaged(pagedUsers.Users, request.PaginationOptions.PageNumber,
            request.PaginationOptions.PageSize, pagedUsers.TotalRecords, endPointUrl);
        return Ok(pagedResponse);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Response<GetUserByIdResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
    {
        var user = await userService.GetUserByIdAsync(id);
        var response = ApiResponse.Create(user);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Response<CreateUserResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
    {
        var user = await userService.AddUserAsync(createUserRequest);
        ApiResponse.Create(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Response<UpdateUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest updateUserRequest)
    {
        var user = await userService.UpdateUserAsync(id, updateUserRequest);
        var response = ApiResponse.Create(user);
        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Response<SoftDeleteUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SoftDeleteUser([FromRoute] Guid id)
    {
        var user = await userService.SoftDeleteUserAsync(id);
        var response = ApiResponse.Create(user);
        return Ok(response);
    }
}