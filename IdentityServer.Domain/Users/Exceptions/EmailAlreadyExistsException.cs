using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Domain.Users.Exceptions;

public sealed class EmailAlreadyExistsException : ValidationException
{
    public EmailAlreadyExistsException(string email) : base($"Email {email} already exists.")
    {
    }
}
