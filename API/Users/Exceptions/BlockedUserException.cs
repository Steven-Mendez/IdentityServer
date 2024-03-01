namespace API.Users.Exceptions;

public class BlockedUserException : Exception
{
    public BlockedUserException() : base("User is blocked.")
    {
    }
}
