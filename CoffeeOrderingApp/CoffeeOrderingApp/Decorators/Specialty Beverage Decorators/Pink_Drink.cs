using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Pink_Drink : Beverage
    {
        string size;
        public Pink_Drink(string coffeeSize)
        {
            size = coffeeSize;
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
