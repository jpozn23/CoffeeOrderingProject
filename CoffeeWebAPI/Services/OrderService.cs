using CoffeeOrderingApp.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeWebAPI
{
    public class OrderService
    {
        static List<Order> orders { get; set; }
        static OrderService()
        {
            orders = new List<Order>();
        }
        public static List<Order> GetAll()
        {

            String myFile = "orders.txt";
            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                orders = JsonConvert.DeserializeObject<List<Order>>(json);
            }
            return orders;
        }

        public static Order Get(Guid id) => orders.FirstOrDefault(p => p.id == id);


        public static void Add(Order order)
        {
            String myFile = "orders.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                orders = JsonConvert.DeserializeObject<List<Order>>(json);
            }

            Order neworder = order;

            orders.Add(neworder);

            File.Delete(myFile);

            String jsonString;
            jsonString = JsonConvert.SerializeObject(orders);

            using (var streamWriter = new StreamWriter(myFile, true))
            {
                streamWriter.WriteLine(jsonString);
            }

        }

        
        public static void Update(Guid id, Order order)
        {
            String myFile = "orders.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                orders = JsonConvert.DeserializeObject<List<Order>>(json);
            }

        
            foreach(Order o in orders)
            {
                if(o.id == id)
                {
                    o.firstname = order.firstname;
                    o.pickupTime = order.pickupTime;
                    o.userName = order.userName;
                    o.beverages = order.beverages;
                    o.id = order.id;
                    o.isCompleted = order.isCompleted;
                    o.drink1 = order.drink1;
                    o.drink2 = order.drink2;
                    o.drink3 = order.drink3;
                    o.drink4 = order.drink4;
                    o.drink5 = order.drink5;
                }
            }


            String jsonString;
            File.Delete(myFile);
            jsonString = JsonConvert.SerializeObject(orders);

            using (var streamWriter = new StreamWriter(myFile, true))
            {
                streamWriter.WriteLine(jsonString);
            }
        }
    }
}
