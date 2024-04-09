namespace IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Responses;

public class CreateUserResponse
{
    public Guid Id { get; init; }
    public string UserName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Avatar { get; init; }
    public bool IsBlocked { get; init; }
}