using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Coffee : Beverage
    {
        public Coffee(string coffeeSize)
        {
            size = coffeeSize;
            drinktype = "Frappuccino";
        }


        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return  4.99;

            }
            else if (size.Equals("Venti"))
            {
                return  5.49;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
