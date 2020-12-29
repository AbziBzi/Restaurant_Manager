using Restaurant_Manager.Models;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Manager.Models_Tests
{
    public class Stock_Tests
    {
        [Fact()]
        public void TestGetProductById_SuccessfulGotten_WhenValidData()
        {
            Stock stock = new Stock();
            StockProduct fish = new StockProduct(new Product(1, "Fish"),   10, "kg",  0.4);
            stock.AddProduct(fish);
            Assert.Equal(fish, stock.GetProductById(fish.Id));
        }

        [Fact()]
        public void TestGetProductById_ThrowsArgumentException_WhenProductNoProductFound()
        {
            Stock stock = new Stock();
            Assert.Throws<ArgumentException>(() => stock.GetProductById(1));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void TestGetProductById_ThrowsArgumentException_WhenIdNegativeOrZero(int productId)
        {
            Stock stock = new Stock();
            Assert.Throws<ArgumentException>(() => stock.GetProductById(productId));
        }

        [Fact()]
        public void TestAddProduct_SuccessfulAdded_WhenValidData()
        {
            Stock stock = new Stock();
            StockProduct fish = new StockProduct(new Product(1, "Fish"), 10, "kg", 0.4);
            stock.AddProduct(fish);
            Assert.Contains(fish, stock.GetProducts());
        }

        [Fact()]
        public void TestAddProduct_ThrowNullException_WhenGivenNull()
        {
            Stock stock = new Stock();
            Assert.Throws<ArgumentNullException>(() => stock.AddProduct(null));
        }

        [Fact()]
        public void TestAddProduct_ThrowArgumentException_WhenItemWithSameIdExist()
        {
            Stock stock = new Stock();
            StockProduct fish = new StockProduct(new Product(1, "Fish"), 10, "kg", 0.4);
            StockProduct potato = new StockProduct(new Product(1, "Potato"), 20, "kg", 0.2);
            stock.AddProduct(fish);
            Assert.Throws<ArgumentException>(() => stock.AddProduct(potato));
        }

        [Fact()]
        public void TestRemoveProduct_SuccessfulRemoved_WhenValidData()
        {
            Stock stock = new Stock();
            StockProduct fish = new StockProduct(new Product(1, "Fish"), 10, "kg", 0.4);
            stock.AddProduct(fish);
            stock.RemoveProduct(fish.Id);
            Assert.DoesNotContain(fish, stock.GetProducts());
        }

        [Fact()]
        public void TestRemoveProduct_ThrowArgumentException_WhenNoProductWithGivenId()
        {
            Stock stock = new Stock();
            Assert.Throws<ArgumentException>(() => stock.RemoveProduct(1));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void TestRemoveProduct_ThrowArgumentException_WhenIdNegativeOrZero(int productId)
        {
            Stock stock = new Stock();
            Assert.Throws<ArgumentException>(() => stock.RemoveProduct(productId));
        }

        [Fact()]
        public void TestUpdateProduct_SuccessfulUpdated_WhenGivenValidData()
        {
            Stock stock = new Stock();
            StockProduct fish = new StockProduct(new Product(1, "Fish"), 10, "kg", 0.4);
            StockProduct newFish = new StockProduct(new Product(1, "Fish"), 20, "kg", 0.2);
            stock.AddProduct(fish);
            stock.UpdateProduct(newFish);
            StockProduct updatedProduct = stock.GetProductById(1);

            Assert.Equal(newFish.Product.Name, updatedProduct.Product.Name);
            Assert.Equal(newFish.Unit, updatedProduct.Unit);
            Assert.Equal(newFish.PortionCount, updatedProduct.PortionCount);
            Assert.Equal(newFish.PortionSize, updatedProduct.PortionSize);
        }

        [Fact()]
        public void TestGetProducts_CollectionEmpty_WhenNoProductsInList()
        {
            Stock stock = new Stock();
            Assert.Empty(stock.GetProducts());
        }
    }
}