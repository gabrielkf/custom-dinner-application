using Contracts.Menus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly ISender _mediator;
    public MenusController(ISender mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public IActionResult CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        return Ok(request);
    } 
}