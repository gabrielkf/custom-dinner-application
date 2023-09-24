using CustomDinner.Domain.Common;
using CustomDinner.Domain.Host.ValueObjects;

namespace CustomDinner.Domain.Dinner.ValueObjects;

public class DinnerId : ValueObject
{
    public Guid Value { get; }

    public DinnerId(Guid value)
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