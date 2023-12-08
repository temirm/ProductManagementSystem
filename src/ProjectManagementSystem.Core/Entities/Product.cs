namespace ProductManagementSystem.Core.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string UnitName { get; private set; }
    public double UnitPrice { get; private set; }
    public int UnitNumber { get; private set; }

    public Product(string name, string unitName, double unitPrice, int unitNumber)
    {
        Name = name;
        UnitName = unitName;

        if (unitPrice < 0)
        {
            // TODO: Use custom exception
            throw new Exception();
        }
        UnitPrice = unitPrice;

        if (unitNumber < 0)
        {
            // TODO: Use custom exception
            throw new Exception();
        }
        UnitNumber = unitNumber;
    }
}
