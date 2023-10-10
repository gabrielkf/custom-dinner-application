using FluentValidation;

namespace CustomDinner.Application.Authentication.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(loginQuery => loginQuery.Email).EmailAddress().NotEmpty();
        RuleFor(loginQuery => loginQuery.Password).NotEmpty();
    }
}