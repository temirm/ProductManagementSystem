using ProjectManagementSystem.Core.Entities;
using ProjectManagementSystem.Core.Interfaces;

namespace ProjectManagementSystem.Core;

public class ExcelParser : IExcelParser
{
    public IEnumerable<Product> ParseProductData()
    {
        return new List<Product>
        {
            new Product("Ручка", "штука", 1.5, 150),
            new Product("Бумага А4", "упаковка", 2.6, 50),
            new Product("Доска маркерная", "штука", 32, 11),
            new Product("Блокнот 100 страниц", "штука", 10, 5),
        };
    }
}
