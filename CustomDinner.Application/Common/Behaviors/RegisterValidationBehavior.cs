using CustomDinner.Application.Authentication.Commands.Common;
using CustomDinner.Application.Authentication.Commands.Register;
using ErrorOr;
using MediatR;

namespace CustomDinner.Application.Common.Behaviors;

public class RegisterValidationBehavior : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request,
        RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next,
        CancellationToken cancellationToken)
    {
        var result = await next();

        return result;
    }
}