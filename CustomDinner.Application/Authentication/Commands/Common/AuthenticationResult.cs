using CustomDinner.Domain.UserAggregate;

namespace CustomDinner.Application.Authentication.Commands.Common;

public record AuthenticationResult(
    User User,
    string Token);