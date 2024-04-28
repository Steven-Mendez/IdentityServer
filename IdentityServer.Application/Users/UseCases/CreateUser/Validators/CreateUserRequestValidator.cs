using FluentValidation;
using IdentityServer.Application.Users.UseCases.CreateUser.DataTransferObjects.Requests;

namespace IdentityServer.Application.Users.UseCases.CreateUser.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
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

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
    }
}