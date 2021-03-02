using System;

namespace joshuaford_project1.Library
{
    public interface IProduct
    {
        public void AddProductToOrder(Enum productToAdd);

        public void CheckProductInventory(Enum productToCheck);

        public void GetProductPrice(Enum productToPrice);
    }
}
