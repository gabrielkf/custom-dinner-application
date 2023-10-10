using FluentValidation;

namespace CustomDinner.Application.Authentication.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(registerCommand => registerCommand.FirstName).NotEmpty();
        RuleFor(registerCommand => registerCommand.LastName).NotEmpty();
        RuleFor(registerCommand => registerCommand.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(registerCommand => registerCommand.Password)
            .NotEmpty()
            .MinimumLength(6);
    }
}