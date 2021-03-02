using System;
using System.Collections.Generic;

#nullable disable

namespace joshuaford_project1.Database
{
    public partial class Order
    {
        public Order()
        {
            CustomerHistories = new HashSet<CustomerHistory>();
            EmployeeHistories = new HashSet<EmployeeHistory>();
            OrderLines = new HashSet<OrderLine>();
        }

        public int OrderId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public double OrderTotal { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<CustomerHistory> CustomerHistories { get; set; }
        public virtual ICollection<EmployeeHistory> EmployeeHistories { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
