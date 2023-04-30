using System.Net;

using Contracts.Authentication;
using CustomDinner.Api.Filters;
using CustomDinner.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CustomDinner.Api.Controllers;

[ApiController]
[Route("auth")]
[ErrorHandlingFilter]
public class AuthenticationController : ControllerBase
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

        var registerResponse = new AuthenticationResponse(
            registerResult.User.Id,
            registerResult.User.FirstName,
            registerResult.User.LastName,
            registerResult.User.Email,
            registerResult.Token);
        
        return Ok(registerResponse);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        var loginResult = _authenticationService.Login(
            loginRequest.Email,
            loginRequest.Password);
        
        var loginResponse = new AuthenticationResponse(
            loginResult.User.Id,
            loginResult.User.FirstName,
            loginResult.User.LastName,
            loginResult.User.Email,
            loginResult.Token);

        return Ok(loginResponse);
    }
}