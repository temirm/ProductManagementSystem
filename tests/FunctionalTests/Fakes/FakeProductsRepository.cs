using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces;

namespace FunctionalTests.Fakes;

public class FakeProductsRepository : IProductsRepository
{
    private readonly List<Product> data = new();

    public Task AddListAsync(IEnumerable<Product> products)
    {
        data.AddRange(products);
        return Task.CompletedTask;
    }

    internal IEnumerable<Product> GetData() => data.ToArray();
}
