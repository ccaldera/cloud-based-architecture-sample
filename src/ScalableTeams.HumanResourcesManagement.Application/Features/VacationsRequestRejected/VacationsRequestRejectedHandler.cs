using MediatR;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.DomainEvents;

namespace ScalableTeams.HumanResourcesManagement.Application.Features.VacationsRequestRejected;

public class VacationsRequestRejectedHandler : IRequestHandler<VacationRequestRejected, Unit>
{
    public VacationsRequestRejectedHandler()
    {
    }

    public async Task<Unit> Handle(VacationRequestRejected @event, CancellationToken cancellationToken)
    {
        return await Unit.Task;
    }
}
