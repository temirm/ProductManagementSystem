﻿using FunctionalTests.Fakes;
using ProductManagementSystem.Core;
using ProductManagementSystem.Core.Entities;
using ProductManagementSystem.Core.Interfaces;

namespace FunctionalTests;

public class ProductAddServiceTests
{

    [Fact]
    public async Task Products_CanBe_Added()
    {
        // Arrange
        List<Product> products = new() {
            new Product("Ручка", "штука", 1.5, 150),
            new Product("Бумага A4", "упаковка", 2.6, 50),
            new Product("Доска маркерная", "штука", 32, 11),
            new Product("Блокнот 100 страниц", "штука", 10, 5),
        };

        IExcelParser fakeExcelParser = new FakeExcelParser(products);
        IProductsRepository fakeRepository = new FakeProductsRepository();
        ProductAddService service = new(fakeExcelParser, fakeRepository);

        // Act
        await service.AddProductsAsync("fakeFile.xlsx");

        // Assert
        var actual = (fakeRepository as FakeProductsRepository)!.GetData();
        Assert.Equal(products, actual);
    }
}
