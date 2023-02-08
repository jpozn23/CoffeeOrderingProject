﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp.Classes
{
    public class Order
    {
        public string firstname { get; set; }

        public List<Drink> beverages = new List<Drink>();
        public bool isCompleted { get; set; }


    }
}
