using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp.Classes
{
    public class User
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string customerOrWorker { get; set; }

        public List<Drink> favorites { get; set; }

    }
}
