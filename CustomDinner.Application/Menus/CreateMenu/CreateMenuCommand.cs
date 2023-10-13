using CustomDinner.Domain.HostAggregate.ValueObjects;
using CustomDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace CustomDinner.Application.Menus.CreateMenu;

public record CreateMenuCommand(
    string Name,
    string Description,
    List<MenuSectionCommand> Sections,
    string HostId) : IRequest<ErrorOr<Menu>>;
    
public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items);
    
public record MenuItemCommand(
    string Name,
    string Description);