using MediatR;

namespace Framework.Core.Domain;

public class BaseDomainEvent : INotification
{
    public DateTime CreationDate { get; protected set; } = DateTime.Now;
}