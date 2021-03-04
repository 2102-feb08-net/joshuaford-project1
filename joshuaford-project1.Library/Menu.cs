using System;
using System.Linq;
using System.Collections.Generic;
using joshuaford_project1.Database;
using Microsoft.EntityFrameworkCore;

namespace joshuaford_project1.Library
{
    public class Menu
    {
        static DbContextOptions<joshfordproject0Context> s_dbContextOptions = DataAccess_Library.DatabaseConnectionString();

        public Menu() { }

        /// <summary>
        /// Opens the menu for customer ordering
        /// </summary>
        public static void MenuUI(OrderC order)
        {
            string menuSelection;
            int menuOptions = MenuSize();
            int quantity;
            do
            {
                // Customer UI Initiation
                Console.WriteLine("\t*******************");
                Console.WriteLine("\t*   Order Menu    *");
                Console.WriteLine("\t*******************");
                Console.WriteLine("\t*A: Add Item to Order\n\t*E: Exit");
                menuSelection = Console.ReadLine().ToUpper();
                while (menuSelection != "A" && menuSelection != "E")
                {
                    Console.WriteLine("\tInvalid Menu Selection.");
                    Console.WriteLine("\tPlease choose from the following:");
                    Console.WriteLine("\t*A: Add Item to Order\n\t*E: Exit");
                    menuSelection = Console.ReadLine().ToUpper();
                }

                if (menuSelection == "A")
                {
                    Console.WriteLine("*******************");
                    Console.WriteLine("*      Menu       *");
                    Console.WriteLine("*******************");
                    PrintMenu();
                    menuSelection = Console.ReadLine();
                    while (menuOptions < int.Parse(menuSelection) && int.Parse(menuSelection) < 0)
                    {
                        Console.WriteLine("\tInvalid Menu Selection");
                        Console.WriteLine("\tPlease select from the following:");
                        PrintMenu();
                        menuSelection = Console.ReadLine();
                    }
                    Console.WriteLine("How many would you like?");
                    quantity = int.Parse(Console.ReadLine());

                    var productSelection = OrderC.GetProductSelection(menuSelection);
                    if (productSelection.GetType().Equals((CoffeeTypes.Regular).GetType()))
                    {
                        order.AddProductToOrder((CoffeeTypes)productSelection, quantity);
                    }
                    else
                    {
                        order.AddProductToOrder((FoodTypes)productSelection, quantity);
                    }

                    order.PrintCurrentOrder();
                }
                else if (menuSelection == "E")
                {
                    order.PrintCurrentOrder();
                    Console.WriteLine("\tIs this the correct order?");
                    Console.WriteLine("\tY: Please Order\n\tN: Change Order");
                    string correctOrder = Console.ReadLine().ToUpper();
                    if (correctOrder == "Y")
                    {
                        order.PlaceOrder();
                    }
                    // Add ability to change order

                    Console.WriteLine("Thanks for stopping by!");
                }
                // Validation should prevent this
                else
                {
                    Console.WriteLine("Applcation closed due to validation error.");
                }
            } while (menuSelection != "E");
        }

        /// <summary>
        /// Returns the total item amount on the menu
        /// </summary>
        /// <returns></returns>
        public static int MenuSize()
        {
            using var context = new joshfordproject0Context(s_dbContextOptions);

            var totalMenuItems = context.Products.Select(x => x.ProductId).Max();

            return totalMenuItems;
        }

        /// <summary>
        /// Print the store Menu
        /// </summary>
        public static void PrintMenu()
        {
            using var context = new joshfordproject0Context(s_dbContextOptions);

            var totalMenuItems = context.Products.Select(x => x.ProductId).Max();
            IQueryable<Product> menu = context.Products
                .OrderBy(x => x.ProductName);
            int menuLine = 1;

            foreach (Product products in menu)
            {
                Console.WriteLine($"{menuLine}: {products.ProductName}\t${products.ProductPrice}");
                menuLine++;
            }
            Console.WriteLine("\tMenu Choice:\n");
        }
    }
}
