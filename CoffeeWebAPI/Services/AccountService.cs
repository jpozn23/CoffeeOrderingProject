
using CoffeeOrderingApp.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeWebAPI
{
    public class AccountService
    {
        static List<User> accounts { get; set; }
        static AccountService()
        {
            accounts = new List<User>();
        }

        // get all accounts
        public static List<User> GetAll()
        {
            String myFile = "accounts.txt";
            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                accounts = JsonConvert.DeserializeObject<List<User>>(json);
            }
            return accounts;
        }

        // add account
        public static void Add(User user)
        {
            // get all accounts
            String myFile = "accounts.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                accounts = JsonConvert.DeserializeObject<List<User>>(json);
            }

            // add account
            User newuser = user;

            accounts.Add(newuser);

            File.Delete(myFile);

            // rewrite to file
            String jsonString;
            jsonString = JsonConvert.SerializeObject(accounts);

            using (var streamWriter = new StreamWriter(myFile, true))
            {
                streamWriter.WriteLine(jsonString);
            }

        }

        // update account
        public static void Update(string username, User user)
        {
            // get all accounts
            String myFile = "accounts.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                accounts = JsonConvert.DeserializeObject<List<User>>(json);
            }

            // find and update account
            foreach (User u in accounts)
            {
                if (u.username == username)
                {
                    u.firstname = user.firstname;
                    u.lastname = user.lastname;
                    u.username = user.username;
                    u.password = user.password;
                    u.customerOrWorker = user.customerOrWorker;
                    u.favorites = user.favorites;
                    u.favdrink1 = user.favdrink1;
                    u.favdrink2 = user.favdrink2;
                    u.favdrink3 = user.favdrink3;
                    u.favdrink4 = user.favdrink4;
                    u.favdrink5 = user.favdrink5;
                }
            }

            // rewrite to file
            String jsonString;
            File.Delete(myFile);
            jsonString = JsonConvert.SerializeObject(accounts);

            using (var streamWriter = new StreamWriter(myFile, true))
            {
                streamWriter.WriteLine(jsonString);
            }
        }
    }
}
