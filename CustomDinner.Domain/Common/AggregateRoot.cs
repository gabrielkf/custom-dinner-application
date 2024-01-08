namespace CustomDinner.Domain.Common;

public class AggregateRoot<TId> : Entity<TId> where TId : notnull
{
    protected AggregateRoot() { }
    
    protected AggregateRoot(TId id) : base(id) { }
}