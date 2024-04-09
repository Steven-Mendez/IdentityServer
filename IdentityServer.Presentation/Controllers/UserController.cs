using IdentityServer.Application.Implementations;
using IdentityServer.Application.Users.Filters;
using IdentityServer.Application.Users.Interfaces;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.GetAllUsers.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.GetFilteredSortedPaginatedUsers;
using IdentityServer.Application.Users.UseCases.GetUserById.DataTransferObjects.Response;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Responses;
using IdentityServer.Presentation.Responses;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Response<IEnumerable<GetAllUsersResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userService.GetAllUsersAsync();
        var response = ApiResponse.Create(users);
        return Ok(response);
    }

    [HttpGet("Filter-Sort-Pagination")]
    [ProducesResponseType(typeof(PagedResponse<GetFilteredSortedPaginatedUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetWithFilterSortAndPagination([FromQuery] UserFilter? filter,
        [FromQuery] Sorter? sorter, [FromQuery] Pagination pagination)
    {
        var request = new GetFilteredSortedPaginatedUsersRequest(filter, sorter, pagination);
        var pagedUsers = await userService.GetFilteredSortedPaginatedUsersAsync(request);
        var pagedResponse = ApiResponse.CreatePaged(pagedUsers.Users, request.Pagination.Page,
            request.Pagination.PageSize, pagedUsers.TotalRecords);
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