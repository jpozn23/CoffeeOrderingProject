using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeWebAPI.Classes
{
    public class UserOrder
    {
        public Guid id { get; set; }
        public string userName { get; set; }
        public string firstname { get; set; }
        public DateTime pickupTime { get; set; }
        public bool isCompleted { get; set; }

        public List<UserDrink> beverages = new List<UserDrink>();
    }
}
