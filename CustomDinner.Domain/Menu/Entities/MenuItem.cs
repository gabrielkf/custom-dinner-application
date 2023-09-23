using CustomDinner.Domain.Menu.ValueObjects;
using CustomDinner.Domain.Models;

namespace CustomDinner.Domain.Menu.Entities;

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
        return new(MenuItemId.CreateUnique(),
            name,
            description,
            price);
    }
}