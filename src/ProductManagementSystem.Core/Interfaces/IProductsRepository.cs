using ProductManagementSystem.Core.Entities;

namespace ProductManagementSystem.Core.Interfaces;

public interface IProductsRepository
{
    Task AddListAsync(IEnumerable<Product> products);
}
