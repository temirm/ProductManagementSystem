namespace ProductManagementSystem.Core.Entities;

public class ProductGroupItem
{
    public Guid ProductId { get; set; }
    public int UnitNumber { get; private set; }

    public Product Product { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private ProductGroupItem() { } // Parameterless constructor for EF Core
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public ProductGroupItem(Product product, int unitNumber)
    {
        Product = product;
        ProductId = product.Id;
        UnitNumber = unitNumber;
    }
}
