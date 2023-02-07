using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Matcha_Green_Tea : Beverage
    {
        public Matcha_Green_Tea(string coffeeSize)
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
