using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp.Base_Beverages
{
    public class SpecialtyBeverage : Beverage
    {
        public SpecialtyBeverage()
        {
            drinktype = "Specialty Beverage";
        }

        public override double Cost()
        {
            return 0.0;
        }
    }
}
