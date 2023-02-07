using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    class Almond_Milk : Decorator
    {
        public Almond_Milk(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }

        public override List<string> GetAddOns()
        {
            beverage.GetAddOns().Add("Almond Milk");
            return beverage.GetAddOns();
        }
    }
}
