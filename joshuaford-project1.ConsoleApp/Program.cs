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
            bool validID = false;
            bool validResponse = false;
            string newOrReturn;
            int menuOptions = 16;
            int quantity = 1;
            string customerFirstName;
            string customerLastName;
            int customerID = 0; 
            int employeeID = 0; 
            int storeID = 1;

            // Database Connection is established
            using var context = new joshfordproject0Context(s_dbContextOptions);

            // User Interface implementation(html, css, js) will be added here
            Console.WriteLine("n or s");

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
                validID = false;

                Console.WriteLine("Please enter customer ID: ");
                customerID = int.Parse(Console.ReadLine());
                do
                {
                    returnCustomer = returnCustomer.FindCustomerByID(customerID);
                    if (!validID)
                    {
                        Console.WriteLine("\tInvalid customer ID entered.");
                        Console.WriteLine("\tPlease enter a valid customer ID: ");
                        customerID = int.Parse(Console.ReadLine());
                    }

                } while (!validID);
                    
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
                string menuSelection;
                OrderC order = new OrderC(customerID, employeeID, storeID);
                do
                {
                    // Customer UI Initiation
                    Console.WriteLine("\t*******************");
                    Console.WriteLine("\t*   Order Menu    *");
                    Console.WriteLine("\t*******************");
                    Console.WriteLine("\t*A: Add Item to Order\n\t*E: Exit");
                    menuSelection = Console.ReadLine().ToUpper();
                    while (menuSelection != "A" && menuSelection != "E")
                    {
                        Console.WriteLine("\tInvalid Menu Selection.");
                        Console.WriteLine("\tPlease choose from the following:");
                        Console.WriteLine("\t*A: Add Item to Order\n\t*E: Exit");
                        menuSelection = Console.ReadLine().ToUpper();
                    }

                    if (menuSelection == "A")
                    {
                        Console.WriteLine("*******************");
                        Console.WriteLine("*      Menu       *");
                        Console.WriteLine("*******************");
                        OrderC.PrintMenu();
                        menuSelection = Console.ReadLine();
                        while (menuOptions < int.Parse(menuSelection) && int.Parse(menuSelection) < 0)
                        {
                            Console.WriteLine("\tInvalid Menu Selection");
                            Console.WriteLine("\tPlease select from the following:");
                            OrderC.PrintMenu();
                            menuSelection = Console.ReadLine();
                        }
                        Console.WriteLine("How many would you like?");
                        quantity = int.Parse(Console.ReadLine());

                        var productSelection = OrderC.GetProductSelection(menuSelection);
                        if (productSelection.GetType().Equals((CoffeeTypes.Regular).GetType()))
                        {
                            order.AddProductToOrder((CoffeeTypes) productSelection, quantity);
                        }
                        else
                        {
                            order.AddProductToOrder((FoodTypes) productSelection, quantity);
                        }

                        order.PrintCurrentOrder();
                    }
                    else if(menuSelection == "E")
                    {
                        order.PrintCurrentOrder();
                        Console.WriteLine("\tIs this the correct order?");
                        Console.WriteLine("\tY: Please Order\n\tN: Change Order");
                        string correctOrder = Console.ReadLine().ToUpper();
                        if (correctOrder == "Y")
                        {
                            order.PlaceOrder();
                        }
                        // Add ability to change order

                        Console.WriteLine("Thanks for stopping by!");
                    }
                    // Validation should prevent this
                    else
                    {
                        Console.WriteLine("Applcation Closed due to validation error.");
                    }

                } while (menuSelection != "E");
            }
            catch (ApplicationException)
            {
                throw new ApplicationException("\tFatal Internal Error.\n\tExiting...");
            }
            
        }
    }
}
