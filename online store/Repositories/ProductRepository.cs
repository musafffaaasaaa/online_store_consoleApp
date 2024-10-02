using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using online_store.Models;

namespace online_store.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _filePath;

        public ProductRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Product> LoadProducts()
        {
            // Load products from JSON file
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
                return products;
            }
            else
            {
                return new List<Product>();
            }
        }

        public void SaveProducts(List<Product> products)
        {
            // Save products to JSON file
            string json = JsonConvert.SerializeObject(products);
            File.WriteAllText(_filePath, json);
        }

        public void AddProduct(Product product)
        {
            List<Product> products = LoadProducts();
            products.Add(product);
            SaveProducts(products);
        }

        public void RemoveProduct(int productId)
        {
            List<Product> products = LoadProducts();
            products.RemoveAll(p => p.Id == productId);
            SaveProducts(products);
        }

        public void UpdateProduct(Product product)
        {
            List<Product> products = LoadProducts();
            products.RemoveAll(p => p.Id == product.Id);
            products.Add(product);
            SaveProducts(products);
        }
    }
}