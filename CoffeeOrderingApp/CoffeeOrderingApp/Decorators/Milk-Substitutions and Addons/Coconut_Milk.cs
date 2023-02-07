using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    class Coconut_Milk : Decorator
    {
        public Coconut_Milk(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }

        public override List<string> GetAddOns()
        {
            beverage.GetAddOns().Add("Coconut Milk");
            return beverage.GetAddOns();
        }
    }
}
