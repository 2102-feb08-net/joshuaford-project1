using System;
using System.Collections.Generic;

#nullable disable

namespace joshuaford_project1.Database
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeHistories = new HashSet<EmployeeHistory>();
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int StoreId { get; set; }
        public string Title { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<EmployeeHistory> EmployeeHistories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
