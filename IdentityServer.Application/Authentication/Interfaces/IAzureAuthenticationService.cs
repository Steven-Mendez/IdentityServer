namespace IdentityServer.Application.Authentication.Interfaces;

public interface IAzureAuthenticationService
{
    string Redirect();
    Task<string> Callback(string code);
}