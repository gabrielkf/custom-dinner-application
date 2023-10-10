using CustomDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CustomDinner.Application.Authentication.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;

