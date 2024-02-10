using MediatR;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.DomainEvents;

namespace ScalableTeams.HumanResourcesManagement.Application.Features.HumanResourcesReviewOpenRequests;

public class NotifyEmployeeHandler : IRequestHandler<VacationRequestApprovedByHumanResources, Unit>
{
    public NotifyEmployeeHandler()
    {
    }

    public  async Task<Unit> Handle(VacationRequestApprovedByHumanResources @event, CancellationToken cancellationToken)
    {
        return await Unit.Task;
    }
}

