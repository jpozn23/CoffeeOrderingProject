using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Caramel : Beverage
    {
        public Caramel(string coffeeSize)
        {
            size = coffeeSize;
            drinktype = "Frappuccino";
        }

        
        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return  5.29;

            }
            else if (size.Equals("Venti"))
            {
                return  5.79;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
