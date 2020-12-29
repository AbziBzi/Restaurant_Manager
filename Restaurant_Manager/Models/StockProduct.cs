using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Manager.Models
{
    public class StockProduct
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int PortionCount { get; set; }
        public string Unit { get; set; }
        public double PortionSize { get; set; }

        public StockProduct(Product product, int portionCount, string unit, double portionSize)
        {
            Product = product;
            Id = product.Id;
            PortionCount = portionCount;
            Unit = unit;
            PortionSize = portionSize;
        }
    }
}
