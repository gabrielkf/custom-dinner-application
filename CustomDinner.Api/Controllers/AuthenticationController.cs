using Contracts.Authentication;
using CustomDinner.Application.Authentication.Commands.Login;
using CustomDinner.Application.Authentication.Commands.Register;
using CustomDinner.Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomDinner.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var command = _mapper.Map<RegisterCommand>(registerRequest);

        var registerResult = await _mediator.Send(command);

        return registerResult.Match(
            successResult => Ok(_mapper.Map<AuthenticationResponse>(successResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var query = _mapper.Map<LoginQuery>(loginRequest);

        var loginResult = await _mediator.Send(query);

        if (loginResult.IsError && loginResult == AppErrors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized,
                title: loginResult.FirstError.Description);
        }

        return loginResult.Match(
            success => Ok(_mapper.Map<AuthenticationResponse>(success)),
            errors => Problem(errors));
    }
}