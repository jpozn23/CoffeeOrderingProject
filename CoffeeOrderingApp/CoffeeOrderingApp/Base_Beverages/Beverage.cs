using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public abstract class Beverage
    {
        public abstract string GetAddSubs();
        public abstract string GetDrinkType();
        public abstract string GetDrinkSize();

        public abstract double Cost();

    }
}
