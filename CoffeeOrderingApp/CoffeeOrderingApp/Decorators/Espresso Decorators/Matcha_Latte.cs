using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Matcha_Latte : Decorator
    {
        public Matcha_Latte(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Matcha Latte " + beverage.Description();
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return beverage.Cost() + 5.29;

            }
            else if (size.Equals("Venti"))
            {
                return beverage.Cost() + 5.79;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
