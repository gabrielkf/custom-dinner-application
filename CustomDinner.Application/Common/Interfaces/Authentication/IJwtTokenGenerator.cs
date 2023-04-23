using CustomDinner.Domain.Entities;

namespace CustomDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}