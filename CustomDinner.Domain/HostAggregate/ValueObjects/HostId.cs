using CustomDinner.Domain.Common;

namespace CustomDinner.Domain.HostAggregate.ValueObjects;

public class HostId : ValueObject
{
    public Guid Value { get; }

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    public static HostId Create(Guid id)
    {
        return new HostId(id);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}