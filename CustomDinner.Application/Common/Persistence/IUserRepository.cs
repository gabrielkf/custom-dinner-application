using CustomDinner.Domain.Entities;

namespace CustomDinner.Application.Common.Persistence;

public interface IUserRepository
{
    void Add(User user);
    User? GetUserByEmail(string email);
}