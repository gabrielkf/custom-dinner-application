using CustomDinner.Domain.Common;

namespace CustomDinner.Domain.Dinner.ValueObjects;

public class DinnerReservationId : ValueObject
{
    public Guid Value { get; }

    private DinnerReservationId(Guid value)
    {
        Value = value;
    }

    public static DinnerReservationId CreateUnique()
    {
        return new DinnerReservationId(Guid.NewGuid());
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}