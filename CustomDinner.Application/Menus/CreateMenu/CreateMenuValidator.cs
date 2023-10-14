using FluentValidation;

namespace CustomDinner.Application.Menus.CreateMenu;

public class CreateMenuValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuValidator()
    {
        RuleFor(menu => menu.Name).NotEmpty();
        RuleFor(menu => menu.Description).NotEmpty();
        RuleFor(menu => menu.Sections).NotEmpty();
    }
}