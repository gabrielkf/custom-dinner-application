using FluentValidation;

namespace CustomDinner.Application.Authentication.Commands.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(loginQuery => loginQuery.Email).NotEmpty();
        RuleFor(loginQuery => loginQuery.Password).NotEmpty();
    }
}