﻿using FluentValidation;
using FluentValidation.Results;
using IdentityServer.Domain.Users.Entities;

namespace IdentityServer.Domain.Users.Exceptions;

public sealed class UserNameAlreadyExistsException(string userName) : ValidationException(_errorMessage, BuildErrors(userName))
{
    private static readonly string _errorMessage = "Domain Exception: UserNameAlreadyExistsException";

    private static IEnumerable<ValidationFailure> BuildErrors(string userName) =>
    [
        new(nameof(User.UserName), $"Username '{userName}' already exists.", userName)
    ];
}
