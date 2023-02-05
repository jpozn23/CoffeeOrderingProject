using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Pink_Drink : Decorator
    {
        public Pink_Drink(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Pink Drink " + beverage.Description();
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return beverage.Cost() + 4.99;

            }
            else if (size.Equals("Venti"))
            {
                return beverage.Cost() + 5.69;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
