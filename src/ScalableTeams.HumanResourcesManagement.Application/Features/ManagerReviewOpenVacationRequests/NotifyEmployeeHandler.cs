using MediatR;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.DomainEvents;

namespace ScalableTeams.HumanResourcesManagement.Application.Features.ManagerReviewOpenVacationRequests;

public class NotifyEmployeeHandler : IRequestHandler<VacationRequestApprovedByManager, Unit>
{
    public NotifyEmployeeHandler()
    {
    }

    public async Task<Unit> Handle(VacationRequestApprovedByManager @event, CancellationToken cancellationToken)
    {
        return await Unit.Task;
    }
}
