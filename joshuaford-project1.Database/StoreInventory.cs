using System;
using System.Collections.Generic;

#nullable disable

namespace joshuaford_project1.Database
{
    public partial class StoreInventory
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public int StoreId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
