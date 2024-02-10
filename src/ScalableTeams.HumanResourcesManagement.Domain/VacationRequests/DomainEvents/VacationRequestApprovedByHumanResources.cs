using MediatR;
using ScalableTeams.HumanResourcesManagement.Domain.DomainEvents;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.Entities;

namespace ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.DomainEvents;

public class VacationRequestApprovedByHumanResources : IRequest<Unit>, IDomainEvent
{
    public VacationRequest VacationRequest { get; private set; }

    public VacationRequestApprovedByHumanResources(VacationRequest vacationRequest)
    {
        VacationRequest = vacationRequest;
    }
}
