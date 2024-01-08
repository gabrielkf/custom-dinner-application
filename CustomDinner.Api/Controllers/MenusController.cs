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
        Guid hostId)
    {
        var command = new CreateMenuCommand(
            request.Name,
            request.Description,
            request.Sections
                .Select(s => new MenuSectionCommand(
                        s.Name,
                        s.Description,
                        s.Items
                            .Select(i => new MenuItemCommand(i.Name, i.Description, i.Price))
                            .ToList()))
                .ToList(),
            hostId); 

        var createMenuResult = await _mediator.Send(command);

        return createMenuResult.Match(
            menu => Created($"/menus/{menu.Id}", _mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors));
    } 
}