using FluentValidation;
using IdentityServer.Application.Users.UseCases.UpdateUser.DataTransferObjects.Requests;

namespace IdentityServer.Application.Users.UseCases.UpdateUser.Validators;

/// <summary>
/// Provides validation for updating user requests, ensuring that all user input meets the application's requirements.
/// This class leverages FluentValidation to define and enforce the rules for user input validation.
/// </summary>
public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    /// <summary>
    /// Configures validation rules for <see cref="UpdateUserRequest"/>.
    /// </summary>
    public UpdateUserRequestValidator()
    {
        // Validates the UserName field is not empty, has a length between 4 and 30 characters, and contains only letters and digits.
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .Length(4, 30).WithMessage("UserName must be between 4 and 30 characters.")
            .Must(x => x.All(char.IsLetterOrDigit)).WithMessage("UserName must only contain letters and digits.");

        // Validates the Email field is not empty and follows a valid email format.
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        // Validates the FirstName field, if provided, does not exceed 50 characters.
        RuleFor(x => x.FirstName)
            .MaximumLength(50).When(x => !string.IsNullOrWhiteSpace(x.FirstName))
            .WithMessage("FirstName cannot exceed 50 characters.");

        // Validates the LastName field, if provided, does not exceed 50 characters.
        RuleFor(x => x.LastName)
            .MaximumLength(50).When(x => !string.IsNullOrWhiteSpace(x.LastName))
            .WithMessage("LastName cannot exceed 50 characters.");
    }
}