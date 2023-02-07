using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Teavana_Shaken_Iced_Tea : Beverage
    {
        public Teavana_Shaken_Iced_Tea(string coffeeSize)
        {
            size = coffeeSize;
            drinktype = "Iced Coffee and Tea";
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
    }
}
