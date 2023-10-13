using FluentValidation;

namespace CustomDinner.Application.Authentication.Login;

public class LoginValidator : AbstractValidator<LoginQuery>
{
    public LoginValidator()
    {
        RuleFor(loginQuery => loginQuery.Email).EmailAddress().NotEmpty();
        RuleFor(loginQuery => loginQuery.Password).NotEmpty();
    }
}