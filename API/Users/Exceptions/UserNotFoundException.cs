namespace API.Users.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string identifier, string identifierType) : base($"User with {identifierType} '{identifier}' not found.")
    {
    }
}
