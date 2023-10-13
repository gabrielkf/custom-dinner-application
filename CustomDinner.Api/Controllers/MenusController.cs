using Contracts.Menus;
using CustomDinner.Application.Menus.CreateMenu;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    
    public MenusController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));

        var createMenuResult = await _mediator.Send(command);

        return createMenuResult.Match(
            success => Created($"/menus/{success.Id}", success),
            errors => Problem(errors));
    } 
}