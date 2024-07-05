namespace IdentityServer.Application.Users.UseCases.SelfRegistrationUser.DataTransferObjects.Responses;

public class SelfRegistrationUserResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Avatar { get; set; }
}
