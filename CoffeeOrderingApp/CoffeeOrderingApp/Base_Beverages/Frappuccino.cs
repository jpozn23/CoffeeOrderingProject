﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public class Frappuccino : Beverage
    {

        public Frappuccino()
        {
            drinktype = "Frappuccino";
        }

        public override double Cost()
        {
            return 0.0;
        }

    }
}
