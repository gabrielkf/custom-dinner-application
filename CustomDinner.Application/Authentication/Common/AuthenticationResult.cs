using CustomDinner.Domain.UserAggregate;

namespace CustomDinner.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);