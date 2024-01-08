using CustomDinner.Domain.Common;
using CustomDinner.Domain.GuestAggregate.ValueObjects;
using CustomDinner.Domain.HostAggregate.ValueObjects;
using CustomDinner.Domain.MenuAggregate.ValueObjects;
using CustomDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace CustomDinner.Domain.MenuReviewAggregate;

public class MenuReview : AggregateRoot<MenuReviewId>
{
    public MenuId MenuId { get; private set; }
    public HostId HostId { get; private set; }
    public GuestId GuestId { get; private set; }
    public int Rating { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    #pragma warning disable CS8618
        private MenuReview() { }
    #pragma warning restore CS8618
    
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