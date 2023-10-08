using CustomDinner.Domain.Common;

namespace CustomDinner.Domain.DinnerAggregate.ValueObjects;

public class DinnerId : ValueObject
{
    public Guid Value { get; }

    private DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId CreateUnique()
    {
        return new DinnerId(Guid.NewGuid());
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}