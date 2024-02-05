namespace ScalableTeams.HumanResourcesManagement.Domain.DomainEvents;

public interface IEventDispatcher
{
    Task Dispatch(IDomainEvent domainEvent, CancellationToken cancellationToken);
}
