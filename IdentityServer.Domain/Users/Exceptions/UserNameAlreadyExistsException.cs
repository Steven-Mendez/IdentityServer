using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Domain.Users.Exceptions;

public sealed class UserNameAlreadyExistsException : ValidationException
{
    public UserNameAlreadyExistsException(string userName) : base($"User with username {userName} already exists")
    {
    }
}
