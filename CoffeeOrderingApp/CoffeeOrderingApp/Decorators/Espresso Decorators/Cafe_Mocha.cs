using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Cafe_Mocha : Beverage
    {
        public Cafe_Mocha(string coffeeSize)
        {
            size = coffeeSize;
            drinktype = "Espresso";
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return 4.99;

            }
            else if (size.Equals("Venti"))
            {
                return 5.29;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
