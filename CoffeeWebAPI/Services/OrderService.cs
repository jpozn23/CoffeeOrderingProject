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

        // get all orders
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

        // get specific order
        public static Order Get(Guid id) => orders.FirstOrDefault(p => p.id == id);


        // add order
        public static void Add(Order order)
        {
            // get all orders from file
            String myFile = "orders.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                orders = JsonConvert.DeserializeObject<List<Order>>(json);
            }

            // add order
            Order neworder = order;

            orders.Add(neworder);

            File.Delete(myFile);

            // rewrite to file
            String jsonString;
            jsonString = JsonConvert.SerializeObject(orders);

            using (var streamWriter = new StreamWriter(myFile, true))
            {
                streamWriter.WriteLine(jsonString);
            }

        }

        // update order
        public static void Update(Guid id, Order order)
        {
            // get all orders
            String myFile = "orders.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                orders = JsonConvert.DeserializeObject<List<Order>>(json);
            }

            // get and update order
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

            // rewrite to file
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
