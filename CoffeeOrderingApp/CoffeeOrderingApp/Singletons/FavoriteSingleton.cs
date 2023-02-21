using CoffeeOrderingApp.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp.Singletons
{
    class FavoriteSingleton
    { // storage fields

        public Drink drink { get; set; }

        // singleton stuff
        private static FavoriteSingleton instance = null;
        private static readonly object userModelLock = new object();

        private FavoriteSingleton()
        {

        }

        public static FavoriteSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (userModelLock)
                    {
                        if (instance == null)
                        {
                            instance = new FavoriteSingleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
}