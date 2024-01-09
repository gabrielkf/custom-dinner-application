using CustomDinner.Domain.Common;
using CustomDinner.Domain.GuestAggregate.ValueObjects;
using CustomDinner.Domain.HostAggregate.ValueObjects;
using CustomDinner.Domain.UserAggregate.ValueObjects;

namespace CustomDinner.Domain.UserAggregate;

public class User : AggregateRoot<UserId>
{
    public HostId? HostId { get; private set; }
    public GuestId? GuestId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
    #pragma warning disable CS8618
    private User() {}
    #pragma warning restore CS8618

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