using CoffeeOrderingApp.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeWebAPI.Services
{
    public class MenuService
    {
        static List<DrinkItem> items { get; set; }
        static MenuService()
        {
            items = new List<DrinkItem>();
        }

        public static List<DrinkItem> GetAll()
        {
            String myFile = "menuitems.txt";
            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                items = JsonConvert.DeserializeObject<List<DrinkItem>>(json);
            }
            return items;
        }

        public static DrinkItem Get(string name) => items.FirstOrDefault(p => p.name == name);

        public static void Add(DrinkItem item)
        {
            String myFile = "menuitems.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                items = JsonConvert.DeserializeObject<List<DrinkItem>>(json);
            }

            DrinkItem newitem = item;

            items.Add(newitem);

            File.Delete(myFile);

            String jsonString;
            jsonString = JsonConvert.SerializeObject(items);

            using (var streamWriter = new StreamWriter(myFile, true))
            {
                streamWriter.WriteLine(jsonString);
            }

        }

        public static void Update(string name, DrinkItem item)
        {
            String myFile = "menuitems.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                items = JsonConvert.DeserializeObject<List<DrinkItem>>(json);
            }


            foreach (DrinkItem i in items)
            {
                if (i.name == name)
                {
                    i.category = item.category;
                    i.name = item.name;
                    i.price = item.price;
                }
            }


            String jsonString;
            File.Delete(myFile);
            jsonString = JsonConvert.SerializeObject(items);

            using (var streamWriter = new StreamWriter(myFile, true))
            {
                streamWriter.WriteLine(jsonString);
            }
        }
    }
}
   