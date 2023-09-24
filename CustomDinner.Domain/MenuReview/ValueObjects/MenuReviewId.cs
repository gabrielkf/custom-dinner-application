using CustomDinner.Domain.Common;
using CustomDinner.Domain.Host.ValueObjects;

namespace CustomDinner.Domain.MenuReview.ValueObjects;

public class MenuReviewId : ValueObject
{
    public Guid Value { get; }

    public MenuReviewId(Guid value)
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