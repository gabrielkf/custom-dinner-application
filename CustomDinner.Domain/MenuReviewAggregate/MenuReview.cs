using CustomDinner.Domain.Common;
using CustomDinner.Domain.GuestAggregate.ValueObjects;
using CustomDinner.Domain.HostAggregate.ValueObjects;
using CustomDinner.Domain.MenuAggregate.ValueObjects;
using CustomDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace CustomDinner.Domain.MenuReviewAggregate;

public class MenuReview : AggregateRoot<MenuReviewId>
{
    public MenuId MenuId { get; }
    public HostId HostId { get; }
    public GuestId GuestId { get; }
    public int Rating { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    
    public MenuReview(
        MenuReviewId id,
        MenuId menuId,
        HostId hostId,
        GuestId guestId,
        int rating) : base(id)
    {
        MenuId = menuId;
        HostId = hostId;
        GuestId = guestId;
        Rating = rating;
        
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public static MenuReview Create(MenuId menuId, HostId hostId, GuestId guestId, int rating)
    {
        return new MenuReview(
            MenuReviewId.CreateUnique(),
            menuId,
            hostId,
            guestId,
            rating);
    }
}