using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp.Classes
{
    public class Order
    {
        public Guid id { get; set; }
        public string userName { get; set; }
        public string firstname { get; set; }
        public DateTime pickupTime { get; set; }
        public bool isCompleted { get; set; }

        public List<Drink> beverages { get; set; }

    }
}
