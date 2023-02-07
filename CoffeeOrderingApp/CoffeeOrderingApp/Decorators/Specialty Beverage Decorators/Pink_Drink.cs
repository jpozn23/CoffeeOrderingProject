using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Pink_Drink : Beverage
    {
        public Pink_Drink(string coffeeSize)
        {
            size = coffeeSize;
            drinktype = "Iced Coffee and Tea";
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return  4.99;

            }
            else if (size.Equals("Venti"))
            {
                return 5.69;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
