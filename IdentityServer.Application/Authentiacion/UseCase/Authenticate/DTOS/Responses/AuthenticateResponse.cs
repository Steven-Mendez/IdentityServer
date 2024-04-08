namespace IdentityServer.Application.Authentiacion.UseCase.Authenticate.DTOS.Responses;

public class AuthenticateResponse
{
    public string Token { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime Expires { get; set; }
    public string TokenType { get; set; } = null!;
}