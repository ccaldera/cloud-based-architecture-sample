using ScalableTeams.HumanResourcesManagement.Domain.Departments.Enums;
using ScalableTeams.HumanResourcesManagement.Domain.Repositories;

namespace ScalableTeams.HumanResourcesManagement.Domain.Departments.Repositories;

public interface IDepartmentsRepository : IRepository
{
    Task<bool> EmployeeBelongsToDepartment(Guid employeeId, DepartmentType department);
}
