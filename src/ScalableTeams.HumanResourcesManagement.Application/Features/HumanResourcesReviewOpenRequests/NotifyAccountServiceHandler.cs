using MediatR;
using ScalableTeams.HumanResourcesManagement.Application.Interfaces;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.DomainEvents;

namespace ScalableTeams.HumanResourcesManagement.Application.Features.HumanResourcesReviewOpenRequests;

public class NotifyAccountServiceHandler : IRequestHandler<VacationRequestApprovedByHumanResources, Unit>
{
    private readonly IAccountingService _accountingService;

    public NotifyAccountServiceHandler(IAccountingService accountingService)
    {
        _accountingService = accountingService;
    }

    public async Task<Unit> Handle(VacationRequestApprovedByHumanResources vacationRequestApprovedByHumanResources, CancellationToken cancellationToken)
    {
        await _accountingService.NotifyVacationsRequest(vacationRequestApprovedByHumanResources.VacationRequest, cancellationToken);

        return Unit.Value;
    }
}
