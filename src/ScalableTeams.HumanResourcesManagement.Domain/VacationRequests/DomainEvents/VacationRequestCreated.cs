using MediatR;
using ScalableTeams.HumanResourcesManagement.Domain.DomainEvents;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.Entities;

namespace ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.DomainEvents;

public class VacationRequestCreated : IRequest<Unit>, IDomainEvent
{
    public VacationRequest VacationRequest { get; private set; }

    public VacationRequestCreated(VacationRequest vacationRequest)
    {
        VacationRequest = vacationRequest;
    }
}
