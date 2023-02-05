using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    class Made_With_Lemonade : Decorator
    {
        public Made_With_Lemonade(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return beverage.Description() + " made with Lemonade";
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }
    }
}
