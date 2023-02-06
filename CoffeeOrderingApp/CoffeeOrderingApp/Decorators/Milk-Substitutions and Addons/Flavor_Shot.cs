﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    class Flavor_Shot : Decorator
    {
        public Flavor_Shot(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String Description()
        {
            return beverage.Description() + " with Flavor Shot";
        }

        public override double Cost()
        {
            return beverage.Cost() + 0.99;
        }
    }
}