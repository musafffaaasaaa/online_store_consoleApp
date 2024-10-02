using System;
using System.Collections.Generic;
using System.Linq;
using online_store.Models;
using online_store.Repositories;

namespace online_store.Services
{
    public class ShoppingCart
    {
        private readonly IProductRepository _productRepository;
        private readonly List<Product> _products;

        public ShoppingCart(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(int id)
        {
            Product productToRemove = GetProductById(id);
            if (productToRemove != null)
            {
                _products.Remove(productToRemove);
            }
        }

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
    }
}