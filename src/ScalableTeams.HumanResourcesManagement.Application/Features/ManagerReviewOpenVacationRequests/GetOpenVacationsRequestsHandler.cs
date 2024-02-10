using MediatR;
using ScalableTeams.HumanResourcesManagement.Application.Features.ManagerReviewOpenVacationRequests.Models;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.Enums;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.Repositories;

namespace ScalableTeams.HumanResourcesManagement.Application.Features.ManagerReviewOpenVacationRequests;

public class GetOpenVacationsRequestsHandler : IRequestHandler<GetOpenVacationsRequestsInput, GetOpenVacationsRequestsResult>
{
    private readonly IVacationsRequestRepository _vacationsRequestRepository;

    public GetOpenVacationsRequestsHandler(IVacationsRequestRepository vacationsRequestRepository)
    {
        _vacationsRequestRepository = vacationsRequestRepository;
    }

    public Task<GetOpenVacationsRequestsResult> Handle(GetOpenVacationsRequestsInput input, CancellationToken cancellationToken)
    {
        var requests = _vacationsRequestRepository
            .GetAllVacationsRequests()
            .Where(x =>
                x.Status == VactionRequestsStatus.CreatedByEmployee
                && x.ManagerId == input.ManagerId)
            .ToList();


        var result = new GetOpenVacationsRequestsResult
        {
            Requests = requests
        };

        return Task.FromResult(result);
    }
}
