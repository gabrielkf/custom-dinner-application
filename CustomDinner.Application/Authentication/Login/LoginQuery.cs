using CustomDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CustomDinner.Application.Authentication.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
    