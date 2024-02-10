﻿using MediatR;
using ScalableTeams.HumanResourcesManagement.Domain.DomainEvents;
using ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.Entities;

namespace ScalableTeams.HumanResourcesManagement.Domain.VacationRequests.DomainEvents;

public class VacationRequestRejected : IRequest<Unit>, IDomainEvent
{
    public VacationRequest VacationRequest { get; private set; }

    public VacationRequestRejected(VacationRequest vacationRequest)
    {
        VacationRequest = vacationRequest;
    }
}
