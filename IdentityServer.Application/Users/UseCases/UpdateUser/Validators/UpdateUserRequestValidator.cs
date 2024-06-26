﻿using FluentValidation;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;

namespace IdentityServer.Application.Users.UseCases.UpdateUser.Validators;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .Length(4, 30).WithMessage("UserName must be between 4 and 30 characters.")
            .Must(x => x.All(char.IsLetterOrDigit)).WithMessage("UserName must only contain letters and digits.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.FirstName)
            .MaximumLength(50).When(x => !string.IsNullOrWhiteSpace(x.FirstName))
            .WithMessage("FirstName cannot exceed 50 characters.");

        RuleFor(x => x.LastName)
            .MaximumLength(50).When(x => !string.IsNullOrWhiteSpace(x.LastName))
            .WithMessage("LastName cannot exceed 50 characters.");
    }
}