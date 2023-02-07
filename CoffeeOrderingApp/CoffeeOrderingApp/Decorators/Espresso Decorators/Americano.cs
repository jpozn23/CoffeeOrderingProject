using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Americano : Beverage
    {
        public Americano(string coffeeSize)
        {
            size = coffeeSize;
            drinktype = "Espresso";
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return 3.29;

            }
            else if (size.Equals("Venti"))
            {
                return 3.89;
            }
            else
            {
                return 0.0;
            }
        }

    }
}
