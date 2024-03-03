namespace IdentityServer.Domain.Users.Exceptions;

public class AuthenticationFailedException : Exception
{
    public AuthenticationFailedException() : base("Authentication failed. Invalid username or password.")
    {
    }
}
