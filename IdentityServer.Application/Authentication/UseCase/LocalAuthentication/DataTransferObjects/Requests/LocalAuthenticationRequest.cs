namespace IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Requests;

public class LocalAuthenticationRequest
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
}