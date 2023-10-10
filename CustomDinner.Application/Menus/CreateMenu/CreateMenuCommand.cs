using CustomDinner.Application.Menus.Common;
using CustomDinner.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace CustomDinner.Application.Menus.CreateMenu;

public record CreateMenuCommand(
    string Name,
    string Description,
    List<MenuSection> Sections,
    string HostId) : IRequest<ErrorOr<MenuResult>>;
