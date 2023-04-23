using CustomDinner.Domain.Entities;

namespace CustomDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);