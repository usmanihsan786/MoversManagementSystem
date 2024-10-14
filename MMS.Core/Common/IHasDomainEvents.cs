namespace MMS.Core.Common;

public class IHasDomainEvents
{
    private readonly List<EventBase> _domainEvents;

    public IHasDomainEvents()
    {
        _domainEvents = new List<EventBase>();

    }
    public IReadOnlyList<EventBase> DomainEvent => _domainEvents.AsReadOnly();

    public void RegisterEvent(EventBase domainEvents)
    {
        _domainEvents.Add(domainEvents);

    }


    public void ClearDomainEvents()
    {

            _domainEvents.Clear();
        
    }
}

