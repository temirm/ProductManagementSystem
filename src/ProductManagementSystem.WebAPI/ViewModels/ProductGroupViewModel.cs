using ProductManagementSystem.Core.Entities;

namespace ProductManagementSystem.WebAPI.ViewModels;

public record ProductGroupViewModel
{
    public record ProductGroupItemViewModel(
        Guid ProductId,
        string ProductName,
        string ProductUnitName,
        int ProductUnitNumber);

    public required Guid Id { get; set; }
    public required IEnumerable<ProductGroupItemViewModel> Items { get; set; }

    public static ProductGroupViewModel FromEntity(ProductGroup entity)
    {
        var items = entity
            .GroupItems
            .Select(x => new ProductGroupItemViewModel(x.ProductId,
                                                       x.Product.Name,
                                                       x.Product.UnitName,
                                                       x.UnitNumber));
        return new ProductGroupViewModel()
        {
            Id = entity.Id,
            Items = items
        };
    }
}
