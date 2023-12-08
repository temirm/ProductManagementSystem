using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;

namespace FunctionalTests.Fakes;

public class FakeExcelParser : IExcelParser
{
    private readonly IEnumerable<Product> data;

    public FakeExcelParser(IEnumerable<Product> productsToReturn)
    {
        data = productsToReturn;
    }

    public IEnumerable<Product> ParseProductData(string fileName) => data.ToArray();
}
