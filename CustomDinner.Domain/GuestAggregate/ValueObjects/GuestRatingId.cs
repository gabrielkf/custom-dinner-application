using CustomDinner.Domain.Common;

namespace CustomDinner.Domain.GuestAggregate.ValueObjects;

public class GuestRatingId : ValueObject
{
    public Guid Value { get; }

    private GuestRatingId(Guid value)
    {
        Value = value;
    }

    public static GuestRatingId CreateUnique()
    {
        return new GuestRatingId(Guid.NewGuid());
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}