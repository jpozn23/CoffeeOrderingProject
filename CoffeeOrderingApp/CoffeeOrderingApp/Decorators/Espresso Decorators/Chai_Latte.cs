using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Chai_Latte : Decorator
    {
        public Chai_Latte(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Chai Latte " + beverage.Description();
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return beverage.Cost() + 4.99;

            }
            else if (size.Equals("Venti"))
            {
                return beverage.Cost() + 5.29;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
