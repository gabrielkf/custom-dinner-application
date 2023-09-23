using CustomDinner.Domain.Menu.Entities;
using CustomDinner.Domain.Menu.ValueObjects;
using CustomDinner.Domain.Models;

namespace CustomDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    private readonly List<MenuSection> _sections = new();

    private Menu(MenuId id, string name, string description, float averageRating) : base(id)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
    }

    public Menu Create(string name, string description, float averageRating)
    {
        return new(MenuId.CreateUnique(),
            name,
            description,
            averageRating);
    }
}
