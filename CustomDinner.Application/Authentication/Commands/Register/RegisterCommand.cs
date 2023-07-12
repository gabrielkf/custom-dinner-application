using CustomDinner.Application.Services.Authentication;
using ErrorOr;
using MediatR;

namespace CustomDinner.Application.Authentication.Commands.Register;

public record RegisterCommand : IRequest<ErrorOr<AuthenticationResult>>
{
    public readonly string FirstName;
    public readonly string LastName;
    public readonly string Email;
    public readonly string Password;

    public RegisterCommand(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
}
