using CustomDinner.Domain.Common;

namespace CustomDinner.Domain.UserAggregate.ValueObjects
{
    public class UserId : ValueObject
    {
        public Guid Value { get; }

        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId CreateUnique()
        {
            return new UserId(Guid.NewGuid());
        }
    
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}