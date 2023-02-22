using System;
using CoffeeOrderingApp.Classes;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp.Singletons
{
    class OrderSingleton
    { // storage fields

        public List<Beverage> beverages = new List<Beverage>();

        // singleton stuff
        private static OrderSingleton instance = null;
        private static readonly object userModelLock = new object();
        public Drink drink1 { get; set; }
        public Drink drink2 { get; set; }
        public Drink drink3 { get; set; }
        public Drink drink4 { get; set; }
        public Drink drink5 { get; set; }

        private OrderSingleton()
        {

        }

        public static OrderSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (userModelLock)
                    {
                        if (instance == null)
                        {
                            instance = new OrderSingleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
}