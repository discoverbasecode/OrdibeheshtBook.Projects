using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Core.Domain;

public class AggregateRoot : EntityBase
{
    private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();

    [NotMapped]
    public List<BaseDomainEvent> DomainEvents => _domainEvents;

    public void AddDomainEvent(BaseDomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(BaseDomainEvent eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }
}
