using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public abstract class Beverage
    {
        public string description = "Unknown Beverage";

        public String Description()
        {
            return description;
        }

        public abstract double Cost();

    }
}
