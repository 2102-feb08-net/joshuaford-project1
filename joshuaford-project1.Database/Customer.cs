using System;
using System.Collections.Generic;

#nullable disable

namespace joshuaford_project1.Database
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerHistories = new HashSet<CustomerHistory>();
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public int? StoreId { get; set; }
        public int? PhoneNumber { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<CustomerHistory> CustomerHistories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
