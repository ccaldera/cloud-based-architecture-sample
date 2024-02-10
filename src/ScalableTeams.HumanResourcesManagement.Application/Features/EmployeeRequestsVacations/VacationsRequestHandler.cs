﻿using MediatR;
using ScalableTeams.HumanResourcesManagement.Application.Features.EmployeeRequestsVacations.Models;
using ScalableTeams.HumanResourcesManagement.Domain.Employees.Entities;
using ScalableTeams.HumanResourcesManagement.Domain.Employees.Repositories;
using ScalableTeams.HumanResourcesManagement.Domain.Exceptions;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.Entities;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.Repositories;
using ScalableTeams.HumanResourcesManagement.Domain.ValueObjects;

namespace ScalableTeams.HumanResourcesManagement.Application.Features.EmployeeRequestsVacations;

public class VacationsRequestHandler : IRequestHandler<VacationsRequestInput, Unit>
{
    private readonly IEmployeesRepository _employeesRepository;
    private readonly IVacationsRequestRepository _vacationsRequestRepository;

    public VacationsRequestHandler(
        IEmployeesRepository employeesRepository,
        IVacationsRequestRepository vacationsRequestRepository)
    {
        _employeesRepository = employeesRepository;
        _vacationsRequestRepository = vacationsRequestRepository;
    }

    public async Task<Unit> Handle(VacationsRequestInput input, CancellationToken cancellationToken)
    {
        Employee employee = await _employeesRepository.Get(input.EmployeeId)
            ?? throw new ResourceNotFoundException($"The requested employee id {input.EmployeeId} does not exists");

        _ = employee.ManagerId
            ?? throw new BusinessLogicException("The employee is not assigned to any manager.");

        var vacationsRequest = new VacationRequest(employee, input.Dates);

        ValidateAndThrow(vacationsRequest);

        await _vacationsRequestRepository.Insert(vacationsRequest);

        await _vacationsRequestRepository.SaveChanges(cancellationToken);

        return Unit.Value;
    }

    private static void ValidateAndThrow(VacationRequest target)
    {
        var errors = new List<BusinessRuleError>();

        if (target.EmployeeId == Guid.Empty)
        {
            errors.Add(new BusinessRuleError(nameof(target.EmployeeId), "EmployeeId cannot be empty."));
        }

        if (target.Dates.Count == 0)
        {
            errors.Add(new BusinessRuleError(nameof(target.Dates), "The dates list cannot be empty."));
        }

        if (target.Dates.Any(x => x.Date <= DateTime.UtcNow.Date))
        {
            errors.Add(new BusinessRuleError(nameof(target.Dates), "Dates must be greater than today."));
        }

        if (target.Dates.Any(x => (x.Date - DateTime.UtcNow.Date).Days < 14))
        {
            errors.Add(new BusinessRuleError(nameof(target.Dates), "You cannot request vacations for the next 14 days."));
        }

        if (target.Dates.Any(x => (x.Date - DateTime.UtcNow.Date).Days > 365))
        {
            errors.Add(new BusinessRuleError(nameof(target.Dates), "You cannot request vacations with a date greater than 120 days."));
        }

        if (target.Dates.GroupBy(x => x.Date).Any(x => x.Count() > 1))
        {
            errors.Add(new BusinessRuleError(nameof(target.Dates), "There are some duplicated dates in the request."));
        }

        if (errors.Count != 0)
        {
            throw new BusinessLogicExceptions(errors);
        }
    }
}
