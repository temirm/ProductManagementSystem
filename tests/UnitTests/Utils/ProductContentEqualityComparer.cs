using ProductManagementSystem.Core.Entities;
using System.Diagnostics.CodeAnalysis;

namespace UnitTests.Utils;

public class ProductContentEqualityComparer : IEqualityComparer<Product>
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