﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    class Coconut_Milk : Decorator
    {
        public Coconut_Milk(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string GetAddSubs()
        {
            return beverage.GetAddSubs() + ", Coconut Milk ";
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
