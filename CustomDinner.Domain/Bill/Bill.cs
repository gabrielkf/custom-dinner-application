using CustomDinner.Domain.Bill.ValueObjects;
using CustomDinner.Domain.Common;
using CustomDinner.Domain.Dinner.ValueObjects;
using CustomDinner.Domain.Guest.ValueObjects;

namespace CustomDinner.Domain.Bill;

public class Bill : AggregateRoot<BillId>
{
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public decimal Amount;
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private Bill(BillId id, DinnerId dinnerId, GuestId guestId, decimal amount) : base(id)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        Amount = amount;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public static Bill Created(DinnerId dinnerId, GuestId guestId, decimal amount)
    {
        return new Bill(
            BillId.CreateUnique(),
            dinnerId,
            guestId,
            amount);
    }
}