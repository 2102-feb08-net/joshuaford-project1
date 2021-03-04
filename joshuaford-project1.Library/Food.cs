using System;
using System.Linq;
using System.Collections.Generic;
using joshuaford_project1.Database;
using Microsoft.EntityFrameworkCore;

namespace joshuaford_project1.Library
{
    public class Food : IProduct
    {
        private List<FoodTypes> currentOrder = new List<FoodTypes>();
        static DbContextOptions<joshfordproject0Context> s_dbContextOptions = DataAccess_Library.DatabaseConnectionString();

        /// <summary>
        /// Constructor to create a food product object, uses product interface
        /// </summary>
        public Food() { }

        /// <summary>
        /// Adds a given food product to the current customers order
        /// </summary>
        /// <param name="productToAdd"></param>
        public void AddProductToOrder(Enum productToAdd)
        {
            currentOrder.Add((FoodTypes)productToAdd);
        }

        /// <summary>
        /// Checks the given food products current amount in the store inventory
        /// </summary>
        /// <param name="productToCheck"></param>
        public void CheckProductInventory(Enum productToCheck)
        {
            using var context = new joshfordproject0Context(s_dbContextOptions);

            FoodTypes foodInvCheck = (FoodTypes)productToCheck;
            int productAmount = 0;

            IQueryable<Product> products = context.Products
                .OrderBy(x => x.ProductName);

            IQueryable<StoreInventory> productInventory = context.StoreInventories
                .OrderBy(x => x.ProductId);

            foreach (Product product in products)
            {
                foreach (StoreInventory storeInventory in productInventory)
                {
                    if(foodInvCheck.ToString().Equals(product.ProductName))
                    {
                        productAmount = storeInventory.ProductQuantity;
                    }
                }
            }

            Console.WriteLine($"Current amount of {foodInvCheck} is: {productAmount}");
        }


        public void GetProductPrice(Enum productToPrice)
        {
            using var context = new joshfordproject0Context(s_dbContextOptions);

            FoodTypes foodToPrice = (FoodTypes)productToPrice;

            var priceOfFood = context.Products
                            .Select(x => x.ProductPrice)
                            .Where(x => x.Equals(foodToPrice.ToString()));
            Console.WriteLine($"{foodToPrice}: $ {priceOfFood}");
        }
    }

    // Menu of Food Items
    public enum FoodTypes
    {
        Bagel,
        Bagel_With_Spread,
        Muffin,
        Muffin_With_Spread,
        Cheese_Pastry,
        Apple_Pastry,
        Strawberry_Pastry,
        Breakfast_Bagel,
        Hashbrowns
    }
}
