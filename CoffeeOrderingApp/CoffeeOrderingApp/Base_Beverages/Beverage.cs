using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public abstract class Beverage
    {
        public string size = "Unknown";
        public string drinktype = "Unknown";
        private List<string> addons = new List<string>();

        public String GetSize()
        {
            return size;
        }

        public String GetDrinkType()
        {
            return drinktype;
        }

        public List<string> GetAddOns()
        {
            return addons;
        }

        public abstract double Cost();

    }
}
