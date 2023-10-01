using CustomDinner.Domain.Common;
using CustomDinner.Domain.Dinner.Entity;
using CustomDinner.Domain.Dinner.ValueObjects;
using CustomDinner.Domain.Host.ValueObjects;

namespace CustomDinner.Domain.Dinner;

public class Dinner : AggregateRoot<DinnerId>
{
    public string Name { get; }
    public string Description { get; }
    public HostId HostId { get; }
    public int MaxReservations { get; }
    public IReadOnlyList<DinnerReservation> DinnerReservations => _dinnerReservations.AsReadOnly();
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private readonly List<DinnerReservation> _dinnerReservations = new();
    
    private Dinner(
        DinnerId id,
        string name,
        string description,
        HostId hostId,
        int maxReservations) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        MaxReservations = maxReservations;
        
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public static Dinner Create(
        string name,
        string description,
        HostId hostId,
        int maxReservations)
    {
        return new Dinner(
            DinnerId.CreateUnique(),
            name,
            description,
            hostId,
            maxReservations);
    }
}