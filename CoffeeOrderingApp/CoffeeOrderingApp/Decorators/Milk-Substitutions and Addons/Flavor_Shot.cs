using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Flavor_Shot : Decorator
    {
        public Flavor_Shot(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string GetAddSubs()
        {
            return beverage.GetAddSubs() + ", Flavor Shot ";
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
