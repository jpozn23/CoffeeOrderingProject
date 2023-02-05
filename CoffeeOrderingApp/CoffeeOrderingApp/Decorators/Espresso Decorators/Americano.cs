using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Americano : Decorator
    {
        public Americano(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Americano " + beverage.Description();
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return beverage.Cost() + 3.29;

            }
            else if (size.Equals("Venti"))
            {
                return beverage.Cost() + 3.89;
            }
            else
            {
                return 0.0;
            }
        }

    }
}
