using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Medicine_Ball : Decorator
    {
        public Medicine_Ball(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Medicine Ball " + beverage.Description();
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return beverage.Cost() + 3.79;

            }
            else if (size.Equals("Venti"))
            {
                return beverage.Cost() + 4.29;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
