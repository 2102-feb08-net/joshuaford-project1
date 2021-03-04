using System;
using System.Linq;
using System.Collections.Generic;
using joshuaford_project1.Database;
using joshuaford_project1.Library;
using Microsoft.EntityFrameworkCore;

namespace joshuaford_project1.ConsoleApp
{
    class Program
    {
        static DbContextOptions<joshfordproject0Context> s_dbContextOptions = DataAccess_Library.DatabaseConnectionString();

        public static void Main(string[] args)
        {
            // Let do this thing
            bool validResponse = false;
            string newOrReturn;
            string customerFirstName;
            string customerLastName;
            int customerID = 0; 
            int employeeID = 1; 
            int storeID = 1;

            // Database Connection is established
            using var context = new joshfordproject0Context(s_dbContextOptions);

            // User Interface implementation(html, css, js) will be added here
            Console.WriteLine("\t**********************************");
            Console.WriteLine("\t* Welcome to Rise 'N Grind Cafe! *");
            Console.WriteLine("\t**********************************");
            Console.WriteLine("\t*N: New Customer\n\t*S: Sign In");

            do
            {
                newOrReturn = Console.ReadLine().ToUpper();

                if (newOrReturn != "N" && newOrReturn != "S")
                {
                    Console.WriteLine("\tInvalid Input.");
                    Console.WriteLine("\tPlease select option from menu below");
                    Console.WriteLine("\t*N: New Customer\n\t*S: Sign In");
                }

                else
                {
                    validResponse = true;
                }

            } while (!validResponse);

            // Returning customer will input ID for ID validation
            // New customer will input name, and receive a customer ID
            // NEEDS REVISING, DOES NOT PROPERLY VALIDATE
            if (newOrReturn == "S")
            {
                CustomerC returnCustomer = new CustomerC();

                Console.WriteLine("Please enter customer ID: ");
                customerID = int.Parse(Console.ReadLine());
                returnCustomer = returnCustomer.FindCustomerByID(customerID);
            }

            else
            {
                CustomerC newCustomer = new CustomerC();

                // New Customer enters first and last name for record keeping
                Console.WriteLine("\t--New Customer Information--");
                Console.WriteLine("\tPlease enter your first name: ");
                customerFirstName = Console.ReadLine();
                while (!newCustomer.ValidateName(customerFirstName))
                {
                    Console.WriteLine("\tName cannot contain spaces");
                    Console.WriteLine("\tPlease enter a valid name: ");
                    customerFirstName = Console.ReadLine();
                }

                Console.WriteLine("\tPlease enter your last name: ");
                customerLastName = Console.ReadLine();
                while (!newCustomer.ValidateName(customerLastName))
                {
                    Console.WriteLine("\tName cannot contain spaces");
                    Console.WriteLine("\tPlease enter a valid name: ");
                    customerLastName = Console.ReadLine();
                }

                CustomerC customerToAdd = new CustomerC();
                customerToAdd.AddNewCustomer(customerFirstName, customerLastName);
                
            }

            // Create Customer Object
            CustomerC customer = new CustomerC();

            try
            {
                OrderC order = new OrderC(customerID, employeeID, storeID);
                Menu.MenuUI(order);
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("\tFatal Internal Error.\n\tExiting...");
            }
            
        }
    }
}
