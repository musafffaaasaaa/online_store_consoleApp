using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_store.Models;

namespace online_store.Repositories
{
    public interface IProductRepository
    {
        List<Product> LoadProducts();
        void SaveProducts(List<Product> products);
        void AddProduct(Product product);
        void RemoveProduct(int productId);
        void UpdateProduct(Product product);
    }
}
