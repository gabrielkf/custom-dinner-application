using CustomDinner.Domain.Common;
using CustomDinner.Domain.Dinner.ValueObjects;
using CustomDinner.Domain.Host.ValueObjects;
using CustomDinner.Domain.Menu.Entities;
using CustomDinner.Domain.Menu.ValueObjects;
using CustomDinner.Domain.MenuReview.ValueObjects;

namespace CustomDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; set; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinners.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _reviews.AsReadOnly();
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinners = new();
    private readonly List<MenuReviewId> _reviews = new();

    private Menu(MenuId id, string name, string description, float averageRating) : base(id)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Menu Create(string name, string description, float averageRating)
    {
        return new(MenuId.CreateUnique(),
            name,
            description,
            averageRating);
    }
}
