using ScalableTeams.HumanResourcesManagement.Domain.DomainEvents;

namespace ScalableTeams.HumanResourcesManagement.Domain.Common.DomainEvents;

public class DomainEventDispatcher : IEventDispatcher
{
    public DomainEventDispatcher()
    {
    }

    public Task Dispatch(IDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        // TODO: Add sender to azure topics
        return Task.CompletedTask;
    }
}
