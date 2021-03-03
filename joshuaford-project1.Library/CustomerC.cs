using System;
using System.Linq;
using System.Collections.Generic;
using joshuaford_project1.Database;
using Microsoft.EntityFrameworkCore;

namespace joshuaford_project1.Library
{
    public class CustomerC
    {
        private int _custID;
        private int _storeID = 1;       // 1 is the main store location
        private string _custFirstName;
        private string _custLastName;
        private int _phoneNumber;
        static DbContextOptions<joshfordproject0Context> s_dbContextOptions = DataAccess_Library.DatabaseConnectionString();

        // Constructor for new customer with no store id or records
        public CustomerC() { }

        /// <summary>
        /// Get and set customer first name
        /// </summary>
        public string CustFirstName { get => _custFirstName; set => _custFirstName = value; }

        /// <summary>
        /// Get and set customer last name
        /// </summary>
        public string CustLastName { get => _custLastName; set => _custLastName = value; }

        /// <summary>
        /// Get and set the customer ID
        /// </summary>
        public int CustID { get => _custID; set => _custID = value; }

        /// <summary>
        /// Get and set customer store ID
        /// </summary>
        public int StoreID { get => _storeID; set => _storeID = value; }

        /// <summary>
        /// Get and set customer phone number(not required)
        /// </summary>
        public int PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }

        /// <summary>
        /// Creates a new customer and adds the customer to the SQL database
        ///     customer table, then sets the local customerID from
        ///     the SQL customer table
        /// </summary>
        public int AddNewCustomer(string custFirstName, string custLastName)
        {
            using var context = new joshfordproject0Context(s_dbContextOptions);

            var customer = new Customer
            {
                CustomerFirstName = custFirstName,
                CustomerLastName = custLastName,
                StoreId = _storeID
            };

            context.Customers.Add(customer);

            context.SaveChanges();

            return _custID;
        }

        /// <summary>
        /// Passes the customer ID to an SQL query to check if the ID exists
        ///     in the customers database
        /// </summary>
        /// <param name="idToValidate"></param>
        /// <returns> boolean idIsValid </returns>
        public CustomerC FindCustomerByID(int idToValidate)
        {
            CustomerC customerC = new CustomerC();
            bool idIsValid = false;

            using var context = new joshfordproject0Context(s_dbContextOptions);

            IQueryable<Customer> customerID = context.Customers
                .OrderBy(x => x.CustomerId);

            foreach (Customer customer in customerID)
            {
                if(idToValidate == customer.CustomerId)
                {
                    idIsValid = true;
                    customerC._custFirstName = customer.CustomerFirstName;
                    customerC._custLastName = customer.CustomerLastName;
                    customerC._custID = idToValidate;
                }
            }

            return customerC;
        }

        /// <summary>
        /// Passes the customer name to a validation function to check
        ///     for spaces in the entered name
        /// </summary>
        /// <param name="idToValidate"></param>
        /// <returns> boolean idIsValid </returns>
        public bool ValidateName(string custName)
        {
            if (custName.Contains(" "))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
