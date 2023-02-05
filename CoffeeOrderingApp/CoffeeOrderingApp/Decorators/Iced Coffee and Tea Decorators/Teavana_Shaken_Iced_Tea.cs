using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Teavana_Shaken_Iced_Tea : Decorator
    {
        public Teavana_Shaken_Iced_Tea(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return "Teavana Shaken Iced Tea " + beverage.Description();
        }
        
        public override double Cost()
        {
            if (size.Equals("Grande"))
            {
                return beverage.Cost() + 2.29;

            }
            else if (size.Equals("Venti"))
            {
                return beverage.Cost() + 2.69;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
