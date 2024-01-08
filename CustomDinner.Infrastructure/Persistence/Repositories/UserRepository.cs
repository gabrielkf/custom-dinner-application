using CustomDinner.Application.Common.Persistence;
using CustomDinner.Domain.UserAggregate;

namespace CustomDinner.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();
    
    public void Add(User user)
    {
        Users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return Users.FirstOrDefault(u => u.Email == email);
    }
}