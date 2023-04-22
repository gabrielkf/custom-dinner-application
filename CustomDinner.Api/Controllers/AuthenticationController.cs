using Contracts.Authentication;

using Microsoft.AspNetCore.Mvc;

namespace CustomDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        return Ok();
    }
}