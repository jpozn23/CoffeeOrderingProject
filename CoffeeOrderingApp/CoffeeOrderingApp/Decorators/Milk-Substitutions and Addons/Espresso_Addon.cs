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

        public override String Description()
        {
            return beverage.Description() + " with Espresso substitute";
        }

        public override double Cost()
        {
           return beverage.Cost() + 2.99;
        }
    }
}
