using ProductManagementSystem.Core.Entities;

namespace ProductManagementSystem.Core.Interfaces;

public interface IGroupsService
{
    Task<IEnumerable<Guid>> ListAll();
    Task<ProductGroup> GetById(Guid id);
}
