using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    class Almond_Milk : Decorator
    {
        public Almond_Milk(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string GetAddSubs()
        {
            return beverage.GetAddSubs() + ", Almond Milk ";
        }


        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }

        public override string GetDrinkType()
        {
            return beverage.GetDrinkType();
        }

        public override string GetDrinkSize()
        {
            return beverage.GetDrinkSize();
        }
    }
}
