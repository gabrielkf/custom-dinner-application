using CustomDinner.Application.Common.Persistence;
using CustomDinner.Application.Menus.Common;
using CustomDinner.Domain.HostAggregate.ValueObjects;
using CustomDinner.Domain.MenuAggregate;
using CustomDinner.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace CustomDinner.Application.Menus.CreateMenu;

public class CreateMenuHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.Create(
            command.Name,
            command.Description,
            HostId.Create(command.HostId),
            command.Sections.Select(
                section => MenuSection.Create(
                    section.Name,
                    section.Description,
                    section.Items.Select(
                        item => MenuItem.Create(
                            item.Name,
                            item.Description,
                            item.Price)))));

        _menuRepository.Add(menu);

        return menu;
    }
}