using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Freshly_Brewed_Coffee : Beverage
    {
        public Freshly_Brewed_Coffee(string coffeeSize)
        {
            size = coffeeSize;
            drinktype = "Espresso";
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return 2.99;

            }
            else if (size.Equals("Venti"))
            {
                return 3.29;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
