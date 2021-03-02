using System;
using System.Collections.Generic;

#nullable disable

namespace joshuaford_project1.Database
{
    public partial class Product
    {
        public Product()
        {
            OrderLines = new HashSet<OrderLine>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
