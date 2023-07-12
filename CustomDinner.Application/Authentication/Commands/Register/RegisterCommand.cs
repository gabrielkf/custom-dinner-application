using CustomDinner.Application.Authentication.Commands.Common;
using ErrorOr;
using MediatR;

namespace CustomDinner.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;

