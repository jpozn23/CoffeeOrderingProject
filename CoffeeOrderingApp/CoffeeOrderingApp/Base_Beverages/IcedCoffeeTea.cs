using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp.Base_Beverages
{
    public class IcedCoffeeTea : Beverage
    {
        public IcedCoffeeTea()
        {
            drinktype = "Iced Coffee and Tea";
        }

        public override double Cost()
        {
            return 0.0;
        }
    }
}
