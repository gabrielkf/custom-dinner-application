using CustomDinner.Domain.Common;
using CustomDinner.Domain.Dinner.ValueObjects;

namespace CustomDinner.Domain.Guest.ValueObjects;

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