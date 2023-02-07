using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Cafe_Latte : Beverage
    {
        public Cafe_Latte(string coffeeSize)
        {
            size = coffeeSize;
            drinktype = "Espresso";
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return 4.49;

            }
            else if (size.Equals("Venti"))
            {
                return 4.99;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
