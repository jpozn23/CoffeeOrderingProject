using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Hot_Tea : Beverage
    {
        string size;
        public Hot_Tea(string coffeeSize)
        {
            size = coffeeSize;
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
            return "Iced Coffee and Tea - Hot Tea";
        }
    }
}
