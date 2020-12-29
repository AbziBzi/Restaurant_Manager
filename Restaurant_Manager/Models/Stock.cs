using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Restaurant_Manager.Models
{
    public class Stock
    {
        private readonly List<StockProduct> _products;

        public Stock()
        {
            _products = new List<StockProduct>();
        }

        public List<StockProduct> GetProducts()
        {
            return _products;
        }

        public StockProduct GetProductById(int id)
        {
            if (id <= 0)
                throw new ArgumentException();
            if (!ContainsId(id))
                throw new ArgumentException();
            return _products.Find(p => p.Id == id);
        }

        public void AddProduct(StockProduct product)
        {
            if (product == null)
                throw new ArgumentNullException();
            if (ContainsId(product.Id))
                throw new ArgumentException();
            _products.Add(product);
        }

        private bool ContainsId(int productId)
        {
            foreach (var product in _products)
            {
                if (product.Id == productId)
                    return true;
            }
            return false;
        }

        public void RemoveProduct(int id)
        {
            if(id <= 0)
                throw new ArgumentException();
            if(!ContainsId(id))
                throw new ArgumentException();
            _products.RemoveAll(p => p.Id == id);
        }

        public void UpdateProduct(StockProduct product)
        {
            StockProduct foundProduct = GetProductById(product.Id);
            if (foundProduct != null)
            {
                foundProduct.PortionCount = product.PortionCount;
                foundProduct.PortionSize = product.PortionSize;
                foundProduct.Unit = foundProduct.Unit;
                foundProduct.Product.Name = foundProduct.Product.Name;
            }

        }
    }
}
