using CustomDinner.Domain.Common;

namespace CustomDinner.Domain.MenuAggregate.ValueObjects;

public class AverageRating : ValueObject
{
    public double Value { get; set; }
    public int NumRatings { get; set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value + NumRatings;
    }
}