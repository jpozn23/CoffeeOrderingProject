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

        public override string GetAddSubs()
        {
            return beverage.GetAddSubs() + ", Made with Lemonade ";
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
