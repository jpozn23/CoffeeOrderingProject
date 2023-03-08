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

        // get all menu items
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

        // get specific menu item
        public static DrinkItem Get(string name) => items.FirstOrDefault(p => p.name == name);

        // add menu item
        public static void Add(DrinkItem item)
        {
            // get menu items
            String myFile = "menuitems.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                items = JsonConvert.DeserializeObject<List<DrinkItem>>(json);
            }

            // add menu item
            DrinkItem newitem = item;

            items.Add(newitem);

            File.Delete(myFile);

            // rewrite to file
            String jsonString;
            jsonString = JsonConvert.SerializeObject(items);

            using (var streamWriter = new StreamWriter(myFile, true))
            {
                streamWriter.WriteLine(jsonString);
            }

        }

        // update menu item
        public static void Update(string name, DrinkItem item)
        {
            // get all menu items
            String myFile = "menuitems.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                items = JsonConvert.DeserializeObject<List<DrinkItem>>(json);
            }

            // find and update menu item
            foreach (DrinkItem i in items)
            {
                if (i.name == name)
                {
                    i.category = item.category;
                    i.name = item.name;
                    i.price = item.price;
                }
            }

            // rewrite to file
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
   