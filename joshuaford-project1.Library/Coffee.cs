using System;
using System.Linq;
using System.Collections.Generic;
using joshuaford_project1.Database;
using Microsoft.EntityFrameworkCore;

namespace joshuaford_project1.Library
{
    public class Coffee : IProduct
    {
        private int _prodID = 0;
        private Dictionary<int, CoffeeTypes> currentOrder = new Dictionary<int, CoffeeTypes>();
        static DbContextOptions<joshfordproject0Context> s_dbContextOptions = DataAccess_Library.DatabaseConnectionString();

        /// <summary>
        /// Constructor to create a coffee product object, uses product interface
        /// </summary>
        public Coffee() { }

        /// <summary>
        /// Adds a given coffee product to the current customers order
        /// </summary>
        /// <param name="productToAdd"></param>
        public void AddProductToOrder(Enum productToAdd)
        {
            currentOrder.Add(_prodID, (CoffeeTypes)productToAdd);
        }

        /// <summary>
        /// Checks the given coffee products current amount in the store inventory
        /// </summary>
        /// <param name="productToCheck"></param>
        public void CheckProductInventory(Enum productToCheck)
        {
            using var context = new joshfordproject0Context(s_dbContextOptions);

            CoffeeTypes coffeeInvCheck = (CoffeeTypes)productToCheck;
            int productAmount = 0;

            // SQL Query for coffee Inventory

            Console.WriteLine($"Current amount of {coffeeInvCheck} is: {productAmount}");
        }

        /// <summary>
        /// Retrieves a given products price
        /// </summary>
        /// <param name="productToPrice"></param>
        public void GetProductPrice(Enum productToPrice)
        {
            using var context = new joshfordproject0Context(s_dbContextOptions);

            CoffeeTypes coffeeToPrice = (CoffeeTypes)productToPrice;

            var priceOfCoffee = context.Products
                .Select(x => x.ProductPrice)
                .Where(x => x.Equals(coffeeToPrice.ToString()));
            Console.WriteLine($"{coffeeToPrice}: $ {priceOfCoffee}");
        }
    }

    // Menu of Coffee Items
    public enum CoffeeTypes
    {
        Regular,
        Decaf,
        Iced_Regular,
        Iced_Decaf,
        Mocha_Latte,
        Vanilla_Latte,
        Cappucino
    }
}
