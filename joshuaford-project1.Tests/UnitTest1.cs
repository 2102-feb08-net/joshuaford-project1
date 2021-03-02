using System;
using joshuaford_project1.Library;
using Xunit;

namespace joshuaford_project1
{
    public class UnitTest1
    {
        [Fact]
        public void Employee_IDValidationTest_EmployeeIDValid()
        {
            // Arrange
            EmployeeC employee = new EmployeeC(1, 1);

            // Act
            int employeeActualID = 1;

            // Assert
            Assert.Equal(employee.ValidateID(employee.EmployeeID), employee.ValidateID(employeeActualID));
        }

        [Fact]
        public void Order_AddCoffeeToOrder_OrderHasCoffee()
        {
            // Arrange
            OrderC expected = new OrderC(1, 1, 1);
            CoffeeTypes coffeeProduct = CoffeeTypes.Regular;
            int coffeeQuantity = 1;
            expected.AddProductToOrder(coffeeProduct, coffeeQuantity);

            // Act
            OrderC actual = new OrderC(1, 1, 1);
            actual.AddProductToOrder(CoffeeTypes.Regular, 1);

            // Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void testTemplate()
        {
            // Arrange


            // Act


            // Assert


        }

        [Fact]
        public void testTemplate1()
        {
            // Arrange


            // Act


            // Assert


        }
    }
}
