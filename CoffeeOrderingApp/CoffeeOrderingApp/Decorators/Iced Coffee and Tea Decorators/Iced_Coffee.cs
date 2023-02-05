using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Iced_Coffee : Decorator
    {
        public Iced_Coffee(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Iced Coffee " + beverage.Description();
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
