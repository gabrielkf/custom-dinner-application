using CustomDinner.Domain.Common;
using CustomDinner.Domain.DinnerAggregate.ValueObjects;
using CustomDinner.Domain.HostAggregate.ValueObjects;
using CustomDinner.Domain.MenuAggregate.Entities;
using CustomDinner.Domain.MenuAggregate.ValueObjects;
using CustomDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace CustomDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    public string Name { get; }
    public string Description { get; }
    public HostId HostId { get; }
    public float AverageRating { get; } = 0;
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinners.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _reviews.AsReadOnly();
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinners = new();
    private readonly List<MenuReviewId> _reviews = new();

    private Menu(
        MenuId id,
        string name,
        string description,
        HostId hostId,
        IEnumerable<MenuSection> sections) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _sections.AddRange(sections);
        
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public static Menu Create(
        string name,
        string description,
        HostId hostId,
        IEnumerable<MenuSection> sections)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            sections);
    }
}
