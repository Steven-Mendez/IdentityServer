namespace IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Requests;

public class SelfRegistrationUserRequest
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Avatar { get; set; }
}
