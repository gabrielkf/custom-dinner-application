using CustomDinner.Domain.Common;
using CustomDinner.Domain.DinnerAggregate.ValueObjects;
using CustomDinner.Domain.HostAggregate.ValueObjects;
using CustomDinner.Domain.MenuAggregate.Entities;
using CustomDinner.Domain.MenuAggregate.ValueObjects;
using CustomDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace CustomDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public HostId HostId { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> ReviewIds => _reviewIds.AsReadOnly();
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _reviewIds = new();
    
    #pragma warning disable CS8618
        private Menu() { }
    #pragma warning restore CS8618

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
        AverageRating = new AverageRating(); // todo: calculate value
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
