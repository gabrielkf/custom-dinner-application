using Contracts.Authentication;
using CustomDinner.Application.Services.Authentication;
using CustomDinner.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CustomDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {
        var registerResult = _authenticationService.Register(
            registerRequest.FirstName,
            registerRequest.LastName,
            registerRequest.Email,
            registerRequest.Password);

        return registerResult.Match(
            success => Ok(
                new AuthenticationResponse(
                    success.User.Id,
                    success.User.FirstName,
                    success.User.LastName,
                    success.User.Email,
                    success.Token)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        var loginResult = _authenticationService.Login(
            loginRequest.Email,
            loginRequest.Password);

        if (loginResult.IsError && loginResult == AppErrors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized,
                title: loginResult.FirstError.Description);
        }

        return loginResult.Match(
            success => Ok(
                new AuthenticationResponse(
                    success.User.Id,
                    success.User.FirstName,
                    success.User.LastName,
                    success.User.Email,
                    success.Token)),
            errors => Problem(errors));
    }
}