namespace ScalableTeams.HumanResourcesManagement.Domain.Repositories;

public interface IRepository
{
    Task SaveChanges(CancellationToken cancellationToken);
}
