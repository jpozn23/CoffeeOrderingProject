using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    class Flavor_Shot : Decorator
    {
        public Flavor_Shot(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }

        public override List<string> GetAddOns()
        {
            beverage.GetAddOns().Add("Flavor Shot");
            return beverage.GetAddOns();
        }
    }
}
