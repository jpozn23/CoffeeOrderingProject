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

        public List<Drink> favorites = new List<Drink>();
        public Drink favdrink1 { get; set; }
        public Drink favdrink2 { get; set; }
        public Drink favdrink3 { get; set; }
        public Drink favdrink4 { get; set; }
        public Drink favdrink5 { get; set; }

    }
}
