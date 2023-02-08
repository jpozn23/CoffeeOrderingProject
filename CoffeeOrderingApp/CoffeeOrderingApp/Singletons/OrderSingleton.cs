using System;
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