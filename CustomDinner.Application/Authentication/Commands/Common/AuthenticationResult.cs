using CustomDinner.Domain.User;

namespace CustomDinner.Application.Authentication.Commands.Common;

public record AuthenticationResult(
    User User,
    string Token);