using CustomDinner.Domain.Common;
using CustomDinner.Domain.MenuAggregate.ValueObjects;

namespace CustomDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; }
    public string Description { get; }
    public decimal Price { get; }
    
    private MenuItem(MenuItemId id, string name, string description, decimal price) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public static MenuItem Create(string name, string description, decimal price)
    {
        return new MenuItem(
            MenuItemId.CreateUnique(),
            name,
            description,
            price);
    }
}