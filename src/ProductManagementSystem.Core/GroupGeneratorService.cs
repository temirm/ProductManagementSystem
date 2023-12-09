using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;

namespace ProductManagementSystem.Core;

public class GroupGeneratorService : IGroupGeneratorService
{
    private readonly IGroupGeneratorAlgorithm algorithm;
    private readonly IProductsRepository productsRepository;
    private readonly IGroupsRepository groupsRepository;

    public GroupGeneratorService(
        IGroupGeneratorAlgorithm algorithm,
        IProductsRepository productsRepository,
        IGroupsRepository groupsRepository)
    {
        this.algorithm = algorithm;
        this.productsRepository = productsRepository;
        this.groupsRepository = groupsRepository;
    }

    public async Task<IEnumerable<Guid>> GenerateGroupsAsync()
    {
        // TODO: Ideally, retrieving not grouped products and adding new groups should be transactional
        IEnumerable<Product> products = await productsRepository.GetNotGroupedAsync();
        
        IEnumerable<ProductGroup> groups = algorithm.GenerateGroups(products);
        
        await groupsRepository.AddListAsync(groups);

        return groups.Select(g => g.Id).ToArray();
    }
}
