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

        public override String Description()
        {
            return beverage.Description() + " with Coconut Milk";
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }
    }
}
