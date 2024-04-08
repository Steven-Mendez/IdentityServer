namespace IdentityServer.Application.Authentiacion.UseCase.Authenticate.DTOS.Requests;

public class AuthenticateRequest
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
}