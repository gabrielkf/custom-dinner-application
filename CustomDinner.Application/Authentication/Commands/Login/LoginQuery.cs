using CustomDinner.Application.Authentication.Commands.Common;
using ErrorOr;
using MediatR;

namespace CustomDinner.Application.Authentication.Commands.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>
{
    public readonly string Email = Email;
    public readonly string Password = Password;
}
