﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    class Flavor_Sauce : Decorator
    {
        public Flavor_Sauce(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }

        public override List<string> GetAddOns()
        {
            beverage.GetAddOns().Add("Flavor Sauce");
            return beverage.GetAddOns();
        }
    }
}
