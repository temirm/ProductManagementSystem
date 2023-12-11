using ProductManagementSystem.Core.Entities;

namespace ProductManagementSystem.Core.Interfaces;

public interface IGroupsRepository
{
    Task AddListAsync(IEnumerable<ProductGroup> groups);
    Task<IEnumerable<ProductGroup>> ListAll();
    Task<ProductGroup?> GetById(Guid id);
}
