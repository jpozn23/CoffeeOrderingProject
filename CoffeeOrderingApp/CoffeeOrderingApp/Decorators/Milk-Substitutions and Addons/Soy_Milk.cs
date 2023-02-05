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

        public override String Description()
        {
            return beverage.Description() + " with Soy Milk";
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }

    }
}
