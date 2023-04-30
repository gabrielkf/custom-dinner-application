using CustomDinner.Application.Common.Interfaces.Authentication;
using CustomDinner.Application.Common.Persistence;
using CustomDinner.Application.Services.Authentication;
using CustomDinner.Domain.Entities;

namespace CustomDinner.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
            throw new Exception("User already registered");

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        
        _userRepository.Add(user);
        
        var jwtToken = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, jwtToken);
    }

    public AuthenticationResult Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);

        if (user is null)
            throw new Exception("User not found");

        if (password != user.Password)
            throw new Exception("Invalid password");
        
        
        var jwtToken = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, jwtToken);
    }
}