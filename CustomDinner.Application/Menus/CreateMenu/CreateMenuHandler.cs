using CustomDinner.Application.Menus.Common;
using CustomDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace CustomDinner.Application.Menus.CreateMenu;

public class CreateMenuHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Create
        // Persist
        // Return
        return default!;
    }
}