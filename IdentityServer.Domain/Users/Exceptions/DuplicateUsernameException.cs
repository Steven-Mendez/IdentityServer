namespace IdentityServer.Domain.Users.Exceptions;

public class DuplicateUsernameException : Exception
{
    public DuplicateUsernameException(string username) : base($"Username '{username}' is already in use.")
    {
    }
}
