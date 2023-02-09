using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Espresso_Addon : Decorator
    {
        public Espresso_Addon(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string GetAddSubs()
        {
            return beverage.GetAddSubs() + ", Espresso ";
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
