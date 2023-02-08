using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Americano : Beverage
    {
        string size;
        public Americano(string coffeeSize)
        {
            size = coffeeSize;
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
