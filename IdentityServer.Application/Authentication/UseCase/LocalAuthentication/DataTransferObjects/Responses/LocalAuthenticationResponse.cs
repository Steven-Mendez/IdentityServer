namespace IdentityServer.Application.Authentication.UseCase.LocalAuthentication.DataTransferObjects.Responses;

public class LocalAuthenticationResponse
{
    public string Token { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime Expires { get; set; }
    public string TokenType { get; set; } = null!;
}