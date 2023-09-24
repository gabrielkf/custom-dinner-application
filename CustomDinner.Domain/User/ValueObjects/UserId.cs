using CustomDinner.Domain.Common;
using CustomDinner.Domain.Host.ValueObjects;

namespace CustomDinner.Domain.User.ValueObjects;

public class UserId : ValueObject
{
    public Guid Value { get; }

    public UserId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}