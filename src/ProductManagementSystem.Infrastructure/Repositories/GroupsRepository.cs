using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;

namespace ProductManagementSystem.Infrastructure.Repositories;

public class GroupsRepository : IGroupsRepository
{
    public Task AddListAsync(IEnumerable<ProductGroup> groups)
    {
        throw new NotImplementedException();
    }

    public Task<ProductGroup> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Guid>> ListAll()
    {
        throw new NotImplementedException();
    }
}
