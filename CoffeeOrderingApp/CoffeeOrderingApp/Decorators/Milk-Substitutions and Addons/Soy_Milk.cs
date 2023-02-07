using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    class Soy_Milk : Decorator
    {
        public Soy_Milk(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }

        public override List<string> GetAddOns()
        {
            beverage.GetAddOns().Add("Soy Milk");
            return beverage.GetAddOns();
        }

    }
}
