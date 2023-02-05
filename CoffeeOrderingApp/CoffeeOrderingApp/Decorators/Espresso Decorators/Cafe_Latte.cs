using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Cafe_Latte : Decorator
    {
        public Cafe_Latte(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Cafe Latte " + beverage.Description();
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return beverage.Cost() + 4.49;

            }
            else if (size.Equals("Venti"))
            {
                return beverage.Cost() + 4.99;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
