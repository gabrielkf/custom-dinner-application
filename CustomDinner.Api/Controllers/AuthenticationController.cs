using Contracts.Authentication;
using CustomDinner.Application.Authentication.Commands.Common;
using CustomDinner.Application.Authentication.Commands.Login;
using CustomDinner.Application.Authentication.Commands.Register;
using CustomDinner.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var command = new RegisterCommand(
            registerRequest.FirstName,
            registerRequest.LastName,
            registerRequest.Email,
            registerRequest.Password);

        var registerResult = await _mediator.Send(command);

        return registerResult.Match(
            successResult => Ok(MapToAuthResponse(successResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var query = new LoginQuery(
            loginRequest.Email,
            loginRequest.Password);

        var loginResult = await _mediator.Send(query);

        if (loginResult.IsError && loginResult == AppErrors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized,
                title: loginResult.FirstError.Description);
        }

        return loginResult.Match(
            success => Ok(MapToAuthResponse(success)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapToAuthResponse(AuthenticationResult authenticationResult)
    {
        return new AuthenticationResponse(
            authenticationResult.User.Id,
            authenticationResult.User.FirstName,
            authenticationResult.User.LastName,
            authenticationResult.User.Email,
            authenticationResult.Token);
    }
}