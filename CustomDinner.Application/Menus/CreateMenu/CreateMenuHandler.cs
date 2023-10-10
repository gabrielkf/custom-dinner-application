using CustomDinner.Application.Menus.Common;
using ErrorOr;
using MediatR;

namespace CustomDinner.Application.Menus.CreateMenu;

public class CreateMenuHandler : IRequestHandler<CreateMenuCommand, ErrorOr<MenuResult>>
{
    public async Task<ErrorOr<MenuResult>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return new MenuResult();
    }
}