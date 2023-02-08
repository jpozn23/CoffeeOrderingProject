using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class White_Chocolate_Mocha : Beverage
    {
        string size;
        public White_Chocolate_Mocha(string coffeeSize)
        {
            size = coffeeSize;
        }


        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return 5.29;

            }
            else if (size.Equals("Venti"))
            {
                return 5.79;
            }
            else
            {
                return 0.0;
            }
        }

        public override string GetAddSubs()
        {
            return "";
        }

        public override string GetDrinkSize()
        {
            return size;
        }

        public override string GetDrinkType()
        {
            return "Espresso";
        }
    }
}
