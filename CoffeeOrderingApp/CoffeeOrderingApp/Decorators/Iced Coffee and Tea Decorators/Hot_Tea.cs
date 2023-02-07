using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Hot_Tea : Beverage
    {
        public Hot_Tea(string coffeeSize)
        {
            size = coffeeSize;
            drinktype = "Iced Coffee and Tea";
        }


        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return  3.29;

            }
            else if (size.Equals("Venti"))
            {
                return  3.49;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
