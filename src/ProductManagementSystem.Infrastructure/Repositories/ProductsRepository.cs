using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;

namespace ProductManagementSystem.Infrastructure.Repositories;

public class ProductsRepository : IProductsRepository
{
    public Task AddListAsync(IEnumerable<Product> products)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetNotGroupedAsync()
    {
        throw new NotImplementedException();
    }
}
