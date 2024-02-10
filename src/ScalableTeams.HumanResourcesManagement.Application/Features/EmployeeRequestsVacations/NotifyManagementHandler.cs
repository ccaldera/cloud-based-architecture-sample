using MediatR;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.DomainEvents;

namespace ScalableTeams.HumanResourcesManagement.Application.Features.EmployeeRequestsVacations;

public class NotifyManagementHandler : IRequestHandler<VacationRequestCreated, Unit>
{
    public NotifyManagementHandler()
    {
    }

    public async Task<Unit> Handle(VacationRequestCreated domainEvent, CancellationToken cancellationToken)
    {
        return await Unit.Task;
    }
}
