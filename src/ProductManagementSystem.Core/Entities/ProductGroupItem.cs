namespace ProductManagementSystem.Core.Entities;

public class ProductGroupItem
{
    public Guid ProductId { get; set; }
    public int UnitNumber { get; private set; }

    public Product Product { get; private set; }

    public ProductGroupItem(Product product, int unitNumber)
    {
        Product = product;
        ProductId = product.Id;
        UnitNumber = unitNumber;
    }
}
