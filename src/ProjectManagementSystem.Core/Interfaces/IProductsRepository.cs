using ProjectManagementSystem.Core.Entities;

namespace ProjectManagementSystem.Core.Interfaces;

public interface IProductsRepository
{
    Task AddListAsync(IEnumerable<Product> products);
}
