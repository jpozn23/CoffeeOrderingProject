using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Medicine_Ball : Beverage
    {
        public Medicine_Ball(string coffeeSize)
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
                return  4.29;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
