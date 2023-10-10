using Contracts.Menus;
using Microsoft.AspNetCore.Mvc;

namespace CustomDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    [HttpPost]
    public IActionResult CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        return Ok(request);
    } 
}