using CustomDinner.Domain.Common;
using CustomDinner.Domain.Dinner.ValueObjects;
using CustomDinner.Domain.Guest.ValueObjects;
using CustomDinner.Domain.Host.ValueObjects;

namespace CustomDinner.Domain.Guest.Entities;

public class GuestRating : Entity<GuestRatingId>
{
    public DinnerId DinnerId { get; }
    public HostId HostId { get; }
    
    private GuestRating(GuestRatingId id, DinnerId dinnerId, HostId hostId) : base(id)
    {
        DinnerId = dinnerId;
        HostId = hostId;
    }

    public static GuestRating Create(DinnerId dinnerId, HostId hostId)
    {
        return new GuestRating(GuestRatingId.CreateUnique(), dinnerId, hostId);
    }
}