using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Freshly_Brewed_Coffee : Decorator
    {
        public Freshly_Brewed_Coffee(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Freshly Brewed Coffee " + beverage.Description();
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return beverage.Cost() + 2.99;

            }
            else if (size.Equals("Venti"))
            {
                return beverage.Cost() + 3.29;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
