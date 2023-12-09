using ProductManagementSystem.Core.Entities;

namespace ProductManagementSystem.Core.Interfaces;

public class GroupsService : IGroupsService
{
    private readonly IGroupsRepository groupsRepository;

    public GroupsService(IGroupsRepository groupsRepository)
    {
        this.groupsRepository = groupsRepository;
    }

    public Task<ProductGroup> GetById(Guid id) => groupsRepository.GetById(id);

    public Task<IEnumerable<Guid>> ListAll() => groupsRepository.ListAll();
}
