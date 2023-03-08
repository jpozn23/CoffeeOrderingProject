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

        public List<Drink> beverages = new List<Drink>();  
        public Drink drink1 { get; set; }
        public Drink drink2 { get; set; }
        public Drink drink3 { get; set; }
        public Drink drink4 { get; set; }
        public Drink drink5 { get; set; }

    }
}
