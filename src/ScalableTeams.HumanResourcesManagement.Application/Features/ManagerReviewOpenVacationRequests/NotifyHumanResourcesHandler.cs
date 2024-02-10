using MediatR;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.DomainEvents;

namespace ScalableTeams.HumanResourcesManagement.Application.Features.ManagerReviewOpenVacationRequests;

public class NotifyHumanResourcesHandler : IRequestHandler<VacationRequestApprovedByManager, Unit>
{
    public NotifyHumanResourcesHandler()
    {
    }

    public async Task<Unit> Handle(VacationRequestApprovedByManager @event, CancellationToken cancellationToken)
    {
        return await Unit.Task;
    }
}
