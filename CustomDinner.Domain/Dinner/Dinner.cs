using CustomDinner.Domain.Common;
using CustomDinner.Domain.Dinner.ValueObjects;
using CustomDinner.Domain.Host.ValueObjects;

namespace CustomDinner.Domain.Dinner;

public class Dinner : AggregateRoot<DinnerId>
{
    public string Name { get; }
    public string Description { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    public HostId HostId { get; set; }
    
    private Dinner(DinnerId id, string name, string description, HostId hostId) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Dinner Create(string name, string description, HostId hostId)
    {
        return new Dinner(
            DinnerId.CreateUnique(),
            name,
            description,
            hostId);
    }
}