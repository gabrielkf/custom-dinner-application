using CustomDinner.Domain.BillAggregate.ValueObjects;
using CustomDinner.Domain.Common;
using CustomDinner.Domain.DinnerAggregate.ValueObjects;
using CustomDinner.Domain.GuestAggregate.Entities;
using CustomDinner.Domain.GuestAggregate.ValueObjects;
using CustomDinner.Domain.MenuReviewAggregate.ValueObjects;
using CustomDinner.Domain.UserAggregate.ValueObjects;

namespace CustomDinner.Domain.GuestAggregate;

public class Guest : AggregateRoot<GuestId>
{
    public UserId UserId { get; }
    public IReadOnlyList<GuestRating> GuestRatings => _guestRatings.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _reviewIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private readonly List<GuestRating> _guestRatings = new();
    private readonly List<MenuReviewId> _reviewIds = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<BillId> _billIds = new();
        
    private Guest(GuestId id, UserId userId) : base(id)
    {
        UserId = userId;
        
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public static Guest Create(UserId userId)
    {
        return new Guest(GuestId.CreateUnique(), userId);
    }
}