using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    class Espresso_Addon : Decorator
    {
        public Espresso_Addon(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }

        public override List<string> GetAddOns()
        {
            beverage.GetAddOns().Add("Espresso");
            return beverage.GetAddOns();
        }
    }
}
