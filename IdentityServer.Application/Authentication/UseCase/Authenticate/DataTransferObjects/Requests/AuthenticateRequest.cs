namespace IdentityServer.Application.Authentication.UseCase.Authenticate.DataTransferObjects.Requests;

public class AuthenticateRequest
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
}