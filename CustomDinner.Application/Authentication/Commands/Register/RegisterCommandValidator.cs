using FluentValidation;

namespace CustomDinner.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(registerCommand => registerCommand.FirstName).NotEmpty();
        RuleFor(registerCommand => registerCommand.LastName).NotEmpty();
        RuleFor(registerCommand => registerCommand.Email).NotEmpty();
        RuleFor(registerCommand => registerCommand.Password).NotEmpty();
    }
}