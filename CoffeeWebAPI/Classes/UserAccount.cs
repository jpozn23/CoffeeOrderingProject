using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeWebAPI.Classes
{
    public class UserAccount
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string customerOrWorker { get; set; }

        public List<UserDrink> favorites { get; set; }
    }
}
