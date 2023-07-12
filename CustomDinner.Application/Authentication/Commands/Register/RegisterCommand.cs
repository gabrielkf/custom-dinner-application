using CustomDinner.Application.Authentication.Commands.Common;
using ErrorOr;
using MediatR;

namespace CustomDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>
{
    public readonly string FirstName = FirstName;
    public readonly string LastName = LastName;
    public readonly string Email = Email;
    public readonly string Password = Password;
}
