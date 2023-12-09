using ProductManagementSystem.Core.Entities;

namespace ProductManagementSystem.Core.Interfaces;

public interface IGroupGeneratorAlgorithm
{
    IEnumerable<ProductGroup> GenerateGroups(IEnumerable<Product> products);
}
