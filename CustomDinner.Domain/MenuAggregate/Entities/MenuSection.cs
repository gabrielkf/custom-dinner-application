using CustomDinner.Domain.Common;
using CustomDinner.Domain.MenuAggregate.ValueObjects;

namespace CustomDinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private readonly List<MenuItem> _items = new();
    
    private MenuSection(
        MenuSectionId id,
        string name,
        string description,
        IEnumerable<MenuItem> items) : base(id)
    {
        Name = name;
        Description = description;
        _items.AddRange(items);
    }

    public static MenuSection Create(
        string name,
        string description,
        IEnumerable<MenuItem> items)
    {
        return new MenuSection(
            MenuSectionId.CreateUnique(),
            name,
            description,
            items);
    }
}