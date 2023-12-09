using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;

namespace ProductManagementSystem.Core;

public class GroupGeneratorService : IGroupGeneratorService
{
    private readonly IGroupGeneratorAlgorithm algorithm;
    private readonly IProductsRepository productsRepository;

    public GroupGeneratorService(IGroupGeneratorAlgorithm algorithm, IProductsRepository productsRepository)
    {
        this.algorithm = algorithm;
        this.productsRepository = productsRepository;
    }

    public async Task<IEnumerable<Guid>> GenerateGroupsAsync()
    {
        IEnumerable<Product> products = await productsRepository.GetNotGroupedAsync();
        return algorithm.GenerateGroups(products).Select(g => g.Id).ToArray();
    }
}
