using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Flavor_Sauce : Decorator
    {
        public Flavor_Sauce(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string GetAddSubs()
        {
            return beverage.GetAddSubs() + ", Flavor Sauce ";
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }

        public override string GetDrinkType()
        {
            return beverage.GetDrinkType();
        }

        public override string GetDrinkSize()
        {
            return beverage.GetDrinkSize();
        }
    }
}
