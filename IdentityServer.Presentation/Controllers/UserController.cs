using IdentityServer.Application.Commons.DataTransferObjects.Requests;
using IdentityServer.Application.Users.Interfaces;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.GetUserById.DataTransferObjects.Response;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.GetUsersByCriteria.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.SoftDeleteUser.DataTransferObjects.Responses;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Responses;
using IdentityServer.Presentation.Responses;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Presentation.Controllers;

/// <summary>
///     Handles user-related operations such as creation, deletion, and querying of user information.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService, IHttpContextAccessor httpContextAccessor) : ControllerBase
{
    private readonly string _baseUrl =
        $"{httpContextAccessor.HttpContext!.Request.Scheme}://{httpContextAccessor.HttpContext!.Request.Host}";

    /// <summary>
    ///     Retrieves a paginated list of users based on criteria.
    /// </summary>
    /// <param name="byCriteriaFilterRequest">Filtering criteria.</param>
    /// <param name="sortingOptions">Sorting options.</param>
    /// <param name="paginationOptions">Pagination options.</param>
    /// <returns>A paginated list of users.</returns>
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

    /// <summary>
    ///     Retrieves a single user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>The requested user if found.</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Response<GetUserByIdResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
    {
        var user = await userService.GetUserByIdAsync(id);
        var response = ApiResponse.Create(user);
        return Ok(response);
    }

    /// <summary>
    ///     Creates a new user with the provided information.
    /// </summary>
    /// <param name="createUserRequest">The information to create a new user.</param>
    /// <returns>The created user.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Response<CreateUserResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
    {
        var user = await userService.AddUserAsync(createUserRequest);
        ApiResponse.Create(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    /// <summary>
    ///     Updates an existing user's information.
    /// </summary>
    /// <param name="id">The unique identifier of the user to update.</param>
    /// <param name="updateUserRequest">The new information for the user.</param>
    /// <returns>The updated user.</returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Response<UpdateUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest updateUserRequest)
    {
        var user = await userService.UpdateUserAsync(id, updateUserRequest);
        var response = ApiResponse.Create(user);
        return Ok(response);
    }

    /// <summary>
    ///     Soft deletes a user, marking them as deleted without actually removing their record.
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete.</param>
    /// <returns>A confirmation of the deletion.</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Response<SoftDeleteUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SoftDeleteUser([FromRoute] Guid id)
    {
        var user = await userService.SoftDeleteUserAsync(id);
        var response = ApiResponse.Create(user);
        return Ok(response);
    }

    /// <summary>
    ///     Allows a new user to register themselves.
    /// </summary>
    /// <param name="createUserRequest">The information for the new user.</param>
    /// <returns>The created user.</returns>
    [HttpPost("self-registration")]
    [ProducesResponseType(typeof(Response<CreateUserResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SelfRegistrationUser([FromBody] SelfRegistrationUserRequest createUserRequest)
    {
        var user = await userService.SelfRegistrationUserAsync(createUserRequest);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }
}