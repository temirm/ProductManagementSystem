using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.GroupGeneratorAlgorithm;
using ProductManagementSystem.Core.Interfaces;

namespace UnitTests;

public class GroupGeneratorAlgorithmTests
{
    [Fact]
    public void Can_Group_Products()
    {
        // Arrange
        List<Product> products = new() {
            new Product("Ручка", "штука", 25, 2) { Id = Guid.NewGuid() },
            new Product("Бумага A4", "упаковка", 45, 1) { Id = Guid.NewGuid() },
            new Product("Доска маркерная", "штука", 50, 1) { Id = Guid.NewGuid() },
            new Product("Блокнот 100 страниц", "штука", 150, 2) { Id = Guid.NewGuid() },
        };
        IGroupGeneratorAlgorithm algorithm = new GroupGeneratorAlgorithm();

        // Act
        IEnumerable<ProductGroup> groups = algorithm.GenerateGroups(products);

        // Assert
        Assert.Equal(3, groups.Count());
        Assert.All(groups, g => Assert.True(g.TotalPrice <= 200));
    }
}
