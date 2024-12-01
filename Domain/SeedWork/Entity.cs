namespace Domain.SeedWork;

public class Entity<T>
{
    public virtual T Id
    {
        get => _id;
        protected set => _id = value;
    }

    private T _id;
    
    // Domain Events can be defined here,
    // or if there is no need to have it in all of entities,
    // then it can be used in an Interface such as IDomainEvent/IHasDomainEvent
    // to add it to the required entity
    // public List<DomainEvent> DomainEvents { get; set; }
}