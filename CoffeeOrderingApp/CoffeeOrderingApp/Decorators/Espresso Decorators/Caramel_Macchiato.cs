using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Caramel_Macchiato : Decorator
    {
        public Caramel_Macchiato(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Caramel Macchiato " + beverage.Description();
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return beverage.Cost() + 5.29;

            }
            else if (size.Equals("Venti"))
            {
                return beverage.Cost() + 5.79;
            }
            else
            {
                return 0.0;
            }
        }

    }
}
