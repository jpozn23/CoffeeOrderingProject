using CoffeeOrderingApp.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp.Singletons
{
    class WorkerOrdersSingleton
    { // storage fields

        public List<Order> orders = new List<Order>();

        // singleton stuff
        private static WorkerOrdersSingleton instance = null;
        private static readonly object userModelLock = new object();

        private WorkerOrdersSingleton()
        {

        }

        public static WorkerOrdersSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (userModelLock)
                    {
                        if (instance == null)
                        {
                            instance = new WorkerOrdersSingleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
}