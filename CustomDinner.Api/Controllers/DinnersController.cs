using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomDinner.Api.Controllers;

[Route("[controller]")]
[Authorize] public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}