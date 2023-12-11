using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;

namespace ProductManagementSystem.Core;

public class GroupsService : IGroupsService
{
    private readonly IGroupsRepository groupsRepository;

    public GroupsService(IGroupsRepository groupsRepository)
    {
        this.groupsRepository = groupsRepository;
    }

    public Task<ProductGroup?> GetById(Guid id) => groupsRepository.GetById(id);

    public async Task<IEnumerable<Guid>> ListAll()
        => (await groupsRepository.ListAll()).Select(g => g.Id);
}
