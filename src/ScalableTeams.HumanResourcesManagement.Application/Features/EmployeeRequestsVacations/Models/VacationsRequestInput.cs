using MediatR;

namespace ScalableTeams.HumanResourcesManagement.Application.Features.EmployeeRequestsVacations.Models;

public class VacationsRequestInput : IRequest<Unit>
{
    public required Guid EmployeeId { get; init; }
    public required List<DateTime> Dates { get; init; }
}
