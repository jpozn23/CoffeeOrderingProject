using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Strawberry_Acai_Refresher : Decorator
    {
        public Strawberry_Acai_Refresher(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Strawberry Angel Refresher " + beverage.Description();
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return beverage.Cost() + 3.79;

            }
            else if (size.Equals("Venti"))
            {
                return beverage.Cost() + 4.29;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
