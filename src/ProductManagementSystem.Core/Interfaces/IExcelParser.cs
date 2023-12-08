using ProductManagementSystem.Core.Entities;

namespace ProductManagementSystem.Core.Interfaces;

public interface IExcelParser
{
    /// <summary>
    /// Parses given Excel input and returns a collection of <see cref="Product"/>.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    IEnumerable<Product> ParseProductData(string fileName);
}
