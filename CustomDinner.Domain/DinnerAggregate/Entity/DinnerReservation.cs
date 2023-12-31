using CustomDinner.Domain.BillAggregate.ValueObjects;
using CustomDinner.Domain.Common;
using CustomDinner.Domain.DinnerAggregate.ValueObjects;
using CustomDinner.Domain.GuestAggregate.ValueObjects;

namespace CustomDinner.Domain.DinnerAggregate.Entity;

public class DinnerReservation : Entity<DinnerReservationId>
{
    public DinnerId DinnerId { get; set; }
    public GuestId GuestId { get; set; }
    public BillId BillId { get; set; }

    private DinnerReservation(DinnerReservationId id, DinnerId dinnerId, GuestId guestId, BillId billId) : base(id)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        BillId = billId;
    }

    public static DinnerReservation Create(DinnerId dinnerId, GuestId guestId, BillId billId)
    {
        return new DinnerReservation(
            DinnerReservationId.CreateUnique(),
            dinnerId,
            guestId,
            billId);
    }
}