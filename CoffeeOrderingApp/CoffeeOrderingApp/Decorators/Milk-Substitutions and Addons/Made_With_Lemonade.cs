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

        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }

        public override List<string> GetAddOns()
        {
            beverage.GetAddOns().Add("Made with Lemonade");
            return beverage.GetAddOns();
        }
    }
}
