using System;
using System.Collections.Generic;

#nullable disable

namespace joshuaford_project1.Database
{
    public partial class Store
    {
        public Store()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
            Orders = new HashSet<Order>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int StoreId { get; set; }
        public string StoreLocation { get; set; }
        public int? StoreManager { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
