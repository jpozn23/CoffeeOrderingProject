using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Strawberry_Acai_Refresher : Beverage
    {
        string size;
        public Strawberry_Acai_Refresher(string coffeeSize)
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
                return 4.29;
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
            return "Specialty Beverage - Refresher";
        }
    }
}
