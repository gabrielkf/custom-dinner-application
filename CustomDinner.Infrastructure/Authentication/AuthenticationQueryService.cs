using CustomDinner.Application.Common.Interfaces.Authentication;
using CustomDinner.Application.Common.Persistence;
using CustomDinner.Application.Services.Authentication;
using CustomDinner.Domain.Entities;
using ErrorOr;
using AppErrors = CustomDinner.Domain.Common.Errors.AppErrors;

namespace CustomDinner.Infrastructure.Authentication;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
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