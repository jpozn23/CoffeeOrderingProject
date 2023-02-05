using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Hot_Tea : Decorator
    {
        public Hot_Tea(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Hot Tea " + beverage.Description();
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return beverage.Cost() + 3.29;

            }
            else if (size.Equals("Venti"))
            {
                return beverage.Cost() + 3.49;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
