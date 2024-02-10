using MediatR;
using ScalableTeams.HumanResourcesManagement.Application.Features.HumanResourcesReviewOpenRequests.Models;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.Enums;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.Repositories;

namespace ScalableTeams.HumanResourcesManagement.Application.Features.HumanResourcesReviewOpenRequests;

public class GetOpenVacationRequestsHandler : IRequestHandler<GetOpenVacationRequestsInput, GetOpenVacationRequestsResult>
{
    private readonly IVacationsRequestRepository _vacationsRequestRepository;

    public GetOpenVacationRequestsHandler(IVacationsRequestRepository vacationsRequestRepository)
    {
        _vacationsRequestRepository = vacationsRequestRepository;
    }

    public Task<GetOpenVacationRequestsResult> Handle(GetOpenVacationRequestsInput input, CancellationToken cancellationToken)
    {
        var requests = _vacationsRequestRepository
            .GetAllVacationsRequests()
            .Where(x => x.Status == VactionRequestsStatus.ApprovedByManager)
            .ToList();

        var result = new GetOpenVacationRequestsResult
        {
            Requests = requests
        };

        return Task.FromResult(result);
    }
}
