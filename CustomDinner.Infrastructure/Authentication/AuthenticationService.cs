using CustomDinner.Application.Common.Interfaces.Authentication;
using CustomDinner.Application.Common.Persistence;
using CustomDinner.Application.Services.Authentication;
using CustomDinner.Domain.Entities;
using ErrorOr;
using AppErrors = CustomDinner.Domain.Common.Errors.AppErrors;

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

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return AppErrors.User.DuplicateEmail;
        }

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

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user || user.Password != password)
        {
            return AppErrors.Authentication.InvalidCredentials;
        }

        var jwtToken = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, jwtToken);
    }
}