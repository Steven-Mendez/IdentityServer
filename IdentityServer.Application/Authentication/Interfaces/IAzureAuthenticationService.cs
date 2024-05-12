namespace IdentityServer.Application.Authentication.Interfaces;

public interface IAzureAuthenticationService
{
    string Redirect();
    string Callback(string code);
}