using CustomDinner.Domain.Common;
using CustomDinner.Domain.GuestAggregate.ValueObjects;
using CustomDinner.Domain.HostAggregate.ValueObjects;
using CustomDinner.Domain.UserAggregate.ValueObjects;

namespace CustomDinner.Domain.UserAggregate;

public class User : AggregateRoot<UserId>
{
    public HostId? HostId { get; }
    public GuestId? GuestId { get; }
    public string FirstName { get; } = null!;
    public string LastName { get; } = null!;
    public string Email { get; } = null!;
    public string Password { get; } = null!;
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private User(
        UserId id,
        string firstName,
        string lastName,
        string email,
        string password,
        HostId? hostId,
        GuestId? guestId) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        HostId = hostId;
        GuestId = guestId;
        
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
    
    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password,
        HostId? hostId = null,
        GuestId? guestId = null)
    {
        return new User(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            hostId,
            guestId);
    }
}