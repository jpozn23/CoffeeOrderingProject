using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Java_Chip : Decorator
    {
        public Java_Chip( Beverage beverage )
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Java Chip " + beverage.Description();
        }

        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return beverage.Cost() + 5.29;

            } else if ( size.Equals("Venti") )
            {
                return beverage.Cost() + 5.79;
            } else
            {
                return 0.0;
            }
        }
    }
}
