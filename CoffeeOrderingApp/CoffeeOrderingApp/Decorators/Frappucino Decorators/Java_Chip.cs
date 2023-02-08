using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Java_Chip : Beverage
    {
        string size;
        public Java_Chip( string coffeeSize )
        {
            size = coffeeSize;
        }


        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return  5.29;

            } else if (size.Equals("Venti") )
            {
                return  5.79;
            } else
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
            return "Frappuccino";
        }
    }
}
