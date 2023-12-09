using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;

namespace ProductManagementSystem.Core.GroupGeneratorAlgorithm;

public class GroupGeneratorAlgorithm : IGroupGeneratorAlgorithm
{
    private const double MAX_GROUP_PRICE = 200;

    private readonly PricedProductsDictionary pricedProducts = new();

    public IEnumerable<ProductGroup> GenerateGroups(IEnumerable<Product> products)
    {
        pricedProducts.InitializeWithProducts(products);

        List<ProductGroup> groups = new();

        while (!pricedProducts.IsEmpty)
        {
            ProductGroup group = new();
            PopulateGroup(group);
            groups.Add(group);
        }

        return groups;
    }

    private void PopulateGroup(ProductGroup group)
    {
        double leftSum = MAX_GROUP_PRICE - group.TotalPrice;
        Product? productToAdd = pricedProducts.PopMostExpensiveProductBelowPrice(leftSum);

        List<Product> totalProductsToAdd = new();

        while (productToAdd is not null) {
            totalProductsToAdd.Add(productToAdd);

            leftSum -= productToAdd.UnitPrice;
            productToAdd = pricedProducts.PopMostExpensiveProductBelowPrice(leftSum);
        }

        var products = totalProductsToAdd.GroupBy(p => p.Id);

        foreach (var product in products)
        {
            ProductGroupItem item = new(product.First(), product.Count());
            group.AddGroupItem(item);
        }
    }
}
