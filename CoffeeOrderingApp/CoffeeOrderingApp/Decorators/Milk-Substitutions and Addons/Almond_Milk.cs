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

        public override String Description()
        {
            return beverage.Description() + " with Almond Milk";
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }
    }
}
