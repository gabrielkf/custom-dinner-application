using CustomDinner.Domain.Common;
using CustomDinner.Domain.DinnerAggregate.ValueObjects;
using CustomDinner.Domain.HostAggregate.ValueObjects;
using CustomDinner.Domain.MenuAggregate.ValueObjects;
using CustomDinner.Domain.UserAggregate.ValueObjects;

namespace CustomDinner.Domain.HostAggregate;

public class Host : AggregateRoot<HostId>
{
    public UserId UserId { get; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();
    
    private Host(HostId id, UserId userId) : base(id)
    {
        UserId = userId;
        
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public static Host Create(UserId userId)
    {
        return new Host(
            HostId.CreateUnique(),
            userId);
    }
}