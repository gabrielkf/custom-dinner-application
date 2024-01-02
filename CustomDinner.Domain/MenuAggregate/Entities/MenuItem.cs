using CustomDinner.Domain.Common;
using CustomDinner.Domain.MenuAggregate.ValueObjects;

namespace CustomDinner.Domain.MenuAggregate.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }

    #pragma warning disable CS8618
        private MenuItem() { }
    #pragma warning restore CS8618
    
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