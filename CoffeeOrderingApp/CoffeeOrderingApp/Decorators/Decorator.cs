using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public abstract class Decorator : Beverage
    {

        public Beverage beverage;
        public String size;

        public abstract String Description();

    }
}
