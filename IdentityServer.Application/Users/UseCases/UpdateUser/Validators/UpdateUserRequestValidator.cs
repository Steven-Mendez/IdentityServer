using FluentValidation;
using IdentityServer.Application.Users.UseCases.UpdateUser.DTO.Requests;

namespace IdentityServer.Application.Users.UseCases.UpdateUser.Validators;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.UserName)
            .Length(4, 30)
            .When(x => !string.IsNullOrWhiteSpace(x.UserName))
            .WithMessage("UserName must be between 4 and 30 characters.")
            .Must(x => x.All(char.IsLetterOrDigit))
            .When(x => !string.IsNullOrWhiteSpace(x.UserName))
            .WithMessage("UserName must only contain letters and digits.");

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Email))
            .WithMessage("Email is not valid.");

        RuleFor(x => x.FirstName)
            .MaximumLength(50)
            .When(x => !string.IsNullOrWhiteSpace(x.FirstName))
            .WithMessage("FirstName cannot exceed 50 characters.");

        RuleFor(x => x.LastName)
            .MaximumLength(50)
            .When(x => !string.IsNullOrWhiteSpace(x.LastName))
            .WithMessage("LastName cannot exceed 50 characters.");
    }
}