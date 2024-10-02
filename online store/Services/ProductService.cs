using online_store.Models;
using online_store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.LoadProducts();
        }

        public void AddProduct(Product product)
        {
            _productRepository.SaveProducts(new List<Product> { product });
        }

        public void RemoveProduct(int productId)
        {
            var products = _productRepository.LoadProducts();
            var productToRemove = products.FirstOrDefault(p => p.Id == productId);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                _productRepository.SaveProducts(products);
            }
        }
    }
}