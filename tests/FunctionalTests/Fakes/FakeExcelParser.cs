using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces;

namespace FunctionalTests.Fakes;

public class FakeExcelParser : IExcelParser
{
    private readonly List<Product> data = new();

    public FakeExcelParser(IEnumerable<Product> productsToReturn)
    {
        data.AddRange(productsToReturn);
    }

    public IEnumerable<Product> ParseProductData() => data;
}
