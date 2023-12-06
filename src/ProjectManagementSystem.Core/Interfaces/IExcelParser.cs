using ProjectManagementSystem.Core.Entities;

namespace ProjectManagementSystem.Core.Interfaces;

public interface IExcelParser
{
    /// <summary>
    /// Parses given Excel input and returns a collection of <see cref="Product"/>.
    /// </summary>
    /// <returns></returns>
    IEnumerable<Product> ParseProductData();
}
