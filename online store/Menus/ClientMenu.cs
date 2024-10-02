using online_store.Repositories;
using online_store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using online_store.Models;

namespace online_store.Menus
{
    public class ClientMenu
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IProductRepository _productRepository;
        private ProductRepository productRepository;
        private ShoppingCart shoppingCart;

        public ClientMenu(ShoppingCart shoppingCart, IProductRepository productRepository)
        {
            _shoppingCart = shoppingCart;
            _productRepository = productRepository;
        }

        public ClientMenu(ProductRepository productRepository, ShoppingCart shoppingCart)
        {
            this.productRepository = productRepository;
            this.shoppingCart = shoppingCart;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. View products");
            Console.WriteLine("2. Add product to cart");
            Console.WriteLine("3. Remove product from cart");
            Console.WriteLine("4. View cart");
            Console.WriteLine("5. Exit");
        }

        public void HandleInput(string input)
        {
            switch (input)
            {
                case "1":
                    // View products
                    List<Product> products = _productRepository.LoadProducts();
                    foreach (Product product in products)
                    {
                        Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "2":
                    // Add product to cart
                    Console.Write("Enter product id: ");
                    int productId = int.Parse(Console.ReadLine());
                    Product productToAdd = _productRepository.LoadProducts().FirstOrDefault(p => p.Id == productId);
                    if (productToAdd != null)
                    {
                        if (!_shoppingCart.GetProducts().Any(p => p.Id == productId))
                        {
                            _shoppingCart.AddProduct(productToAdd);
                            Console.WriteLine("Product added to cart");
                        }
                        else
                        {
                            Console.WriteLine("Product already in cart");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Product not found");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "3":
                    // Remove product from cart
                    Console.Write("Enter product id: ");
                    int productIdToRemove = int.Parse(Console.ReadLine());
                    Product productToRemove = _shoppingCart.GetProducts().FirstOrDefault(p => p.Id == productIdToRemove);
                    if (productToRemove != null)
                    {
                        _shoppingCart.RemoveProduct(productToRemove.Id); // Pass the product ID instead of the product object
                        Console.WriteLine("Product removed from cart");
                    }
                    else
                    {
                        Console.WriteLine("Product not found in cart");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "4":
                    // View cart
                    List<Product> cartProducts = _shoppingCart.GetProducts().ToList();
                    if (cartProducts.Count == 0)
                    {
                        Console.WriteLine("Cart is empty");
                    }
                    else
                    {
                        foreach (Product product in cartProducts)
                        {
                            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "5":
                    // Exit
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}