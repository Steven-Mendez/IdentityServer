using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Presentation.Middlewares.GlobalError.ExtensionMethods;

public static class ExceptionExtensions
{
    public static ValidationProblemDetails ToProblemDetails(this ValidationException exception)
    {
        var error = new ValidationProblemDetails
        {
            Type = @"https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Status = StatusCodes.Status400BadRequest
        };
        foreach (var validationError in exception.Errors)
        {
            if (error.Errors.TryGetValue(validationError.PropertyName, out var value))
            {
                error.Errors[validationError.PropertyName] = value.Concat([validationError.ErrorMessage]).ToArray();
                continue;
            }

            error.Errors.Add(new KeyValuePair<string, string[]>(validationError.PropertyName,
                [validationError.ErrorMessage]));
        }

        return error;
    }
}