using CustomDinner.Domain.UserAggregate;

namespace CustomDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}