using CoffeeOrderingApp.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp.Singletons
{
    class UserSingleton
    { // storage fields
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

        // singleton stuff
        private static UserSingleton instance = null;
        private static readonly object userModelLock = new object();

        private UserSingleton()
        {

        }

        public static UserSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (userModelLock)
                    {
                        if (instance == null)
                        {
                            instance = new UserSingleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
}