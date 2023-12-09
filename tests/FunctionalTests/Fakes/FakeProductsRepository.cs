using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;

namespace FunctionalTests.Fakes;

public class FakeProductsRepository : IProductsRepository
{
    private readonly List<Product> data = new();

    public Task AddListAsync(IEnumerable<Product> products)
    {
        data.AddRange(products);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Product>> GetNotGroupedAsync()
    {
        throw new NotImplementedException();
    }

    internal IEnumerable<Product> GetData() => data.ToArray();
}
