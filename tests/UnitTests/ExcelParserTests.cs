using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace UnitTests;

public class ExcelParserTests
{
    [Fact]
    public void Parser_Returns_Products()
    {
        // Arrange
        string sampleInputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "sample_input.xlsx");
        ExcelParser parser = new();
        
        List<Product> expected = new() {
            new Product("Ручка", "штука", 1.5, 150),
            new Product("Бумага A4", "упаковка", 2.6, 50),
            new Product("Доска маркерная", "штука", 32, 11),
            new Product("Блокнот 100 страниц", "штука", 10, 5),
        };

        // Act
        IEnumerable<Product> parsed = parser.ParseProductData(sampleInputFilePath);

        // Assert
        Assert.Equal(expected, parsed, new ProductContentEqualityComparer());
    }

    private class ProductContentEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            ArgumentNullException.ThrowIfNull(x);
            ArgumentNullException.ThrowIfNull(y);
            return
                x.Name == y.Name && 
                x.UnitName == y.UnitName && 
                x.UnitPrice == y.UnitPrice && 
                x.UnitNumber == y.UnitNumber;
        }

        public int GetHashCode([DisallowNull] Product obj) => obj.GetHashCode();
    }
}