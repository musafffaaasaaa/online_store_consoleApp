using online_store.Menus;
using online_store.Repositories;
using online_store.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using online_store.Models;
using online_store.Tests;

namespace online_store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProductRepository productRepository = new ProductRepository(@"C:\Users\musta\OneDrive\Рабочий стол\online store\Data\testdata.json");

            ShoppingCart shoppingCart = new ShoppingCart(productRepository);

            ClientMenu clientMenu = new ClientMenu(shoppingCart, productRepository);

            while (true)
            {
                clientMenu.DisplayMenu();
                string input = Console.ReadLine();
                clientMenu.HandleInput(input);
            }
        }
    }
}