using ScalableTeams.HumanResourcesManagement.Domain.Employees.Entities;
using ScalableTeams.HumanResourcesManagement.Domain.Entities;

namespace ScalableTeams.HumanResourcesManagement.Domain.Departments.Entities;

public class Department : Entity
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }

    public List<Employee> Members { get; set; } = [];
}
