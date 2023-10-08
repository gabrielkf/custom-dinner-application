using CustomDinner.Application.Authentication.Commands.Common;
using CustomDinner.Application.Common.Interfaces.Authentication;
using CustomDinner.Application.Common.Persistence;
using CustomDinner.Domain.Common.Errors;
using CustomDinner.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace CustomDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler
    : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private IUserRepository _userRepository;
    private IJwtTokenGenerator _jwtTokenGenerator;
    
    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return AppErrors.User.DuplicateEmail;
        }

        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password);
        
        _userRepository.Add(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, token);
    }
}