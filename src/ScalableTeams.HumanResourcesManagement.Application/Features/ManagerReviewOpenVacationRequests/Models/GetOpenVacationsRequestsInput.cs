using MediatR;

namespace ScalableTeams.HumanResourcesManagement.Application.Features.ManagerReviewOpenVacationRequests.Models;

public class GetOpenVacationsRequestsInput : IRequest<GetOpenVacationsRequestsResult>
{
    public Guid ManagerId { get; set; }
}
