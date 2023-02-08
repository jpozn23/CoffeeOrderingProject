using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Hot_Cocoa : Beverage
    {
        string size;
        public Hot_Cocoa(string coffeeSize)
        {
            size = coffeeSize;
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
            return "Specialty Beverage";
        }
    }
}
