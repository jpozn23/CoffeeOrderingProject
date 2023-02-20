﻿using CoffeeWebAPI.Classes;
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
        static List<UserOrder> orders { get; set; }
        static OrderService()
        {
            orders = new List<UserOrder>();
        }
        public static List<UserOrder> GetAll()
        {

            String myFile = "orders.txt";
            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                orders = JsonConvert.DeserializeObject<List<UserOrder>>(json);
            }
            return orders;
        }

        public static UserOrder Get(Guid id) => orders.FirstOrDefault(p => p.id == id);


        public static void Add(UserOrder order)
        {
            String myFile = "orders.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                orders = JsonConvert.DeserializeObject<List<UserOrder>>(json);
            }

            UserOrder neworder = order;

            orders.Add(neworder);

            File.Delete(myFile);

            String jsonString;
            jsonString = JsonConvert.SerializeObject(orders);

            using (var streamWriter = new StreamWriter(myFile, true))
            {
                streamWriter.WriteLine(jsonString);
            }

        }

        
        public static void Update(Guid id, UserOrder order)
        {
            String myFile = "orders.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                orders = JsonConvert.DeserializeObject<List<UserOrder>>(json);
            }

        
            foreach(UserOrder o in orders)
            {
                if(o.id == id)
                {
                    o.firstname = order.firstname;
                    o.pickupTime = order.pickupTime;
                    o.userName = order.userName;
                    o.beverages = order.beverages;
                    o.id = order.id;
                    o.isCompleted = order.isCompleted;
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