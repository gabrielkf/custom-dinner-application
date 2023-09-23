using CustomDinner.Domain.Menu.ValueObjects;
using CustomDinner.Domain.Models;

namespace CustomDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private readonly List<MenuItem> _items = new();
    
    private MenuSection(MenuSectionId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    public MenuSection Create(string name, string description)
    {
        return new(MenuSectionId.CreateUnique(), name, description);
    }
}