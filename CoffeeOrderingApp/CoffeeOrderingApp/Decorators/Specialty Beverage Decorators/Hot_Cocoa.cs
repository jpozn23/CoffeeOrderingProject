using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Hot_Cocoa : Beverage
    {
        public Hot_Cocoa(string coffeeSize)
        {
            size = coffeeSize;
            drinktype = "Iced Coffee and Tea";
        }


        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return  3.79;

            }
            else if (size.Equals("Venti"))
            {
                return  3.99;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
