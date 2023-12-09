namespace ProductManagementSystem.Core.Interfaces;

public interface IGroupGeneratorService
{
    Task<IEnumerable<Guid>> GenerateGroupsAsync();
}
