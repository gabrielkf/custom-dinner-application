using CustomDinner.Domain.UserAggregate;

namespace CustomDinner.Application.Common.Persistence;

public interface IUserRepository
{
    void Add(User user);
    User? GetUserByEmail(string email);
}