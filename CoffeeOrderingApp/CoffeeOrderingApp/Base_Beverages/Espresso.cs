﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Espresso : Beverage
    {

        public Espresso()
        {
            description = "Espresso";
        }

        public override double Cost()
        {
            return 0.0;
        }

    }
}
