using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Hot_Cocoa : Decorator
    {
        public Hot_Cocoa(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Hot Cocoa " + beverage.Description();
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return beverage.Cost() + 3.79;

            }
            else if (size.Equals("Venti"))
            {
                return beverage.Cost() + 3.99;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
