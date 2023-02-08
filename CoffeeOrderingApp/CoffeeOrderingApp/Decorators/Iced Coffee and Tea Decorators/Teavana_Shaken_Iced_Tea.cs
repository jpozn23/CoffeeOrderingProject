using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Teavana_Shaken_Iced_Tea : Beverage
    {
        string size;
        public Teavana_Shaken_Iced_Tea(string coffeeSize)
        {
            size = coffeeSize;
        }

        
        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return  2.29;

            }
            else if (size.Equals("Venti"))
            {
                return  2.69;
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
            return "Iced Coffee and Tea - Teavana Shaken Iced Tea";
        }
    }
}
