using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp.Classes
{
    public class Order
    {
        public string firstname { get; set; }
        public string isCompleted { get; set; }

        public List<Beverage> beverages = new List<Beverage>();

    }
}
