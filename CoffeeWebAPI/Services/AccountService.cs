using CoffeeWebAPI.Classes;
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
        static List<UserAccount> accounts { get; set; }
        static AccountService()
        {
            accounts = new List<UserAccount>();
        }
        public static List<UserAccount> GetAll()
        {

            String myFile = "accounts.txt";
            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                accounts = JsonConvert.DeserializeObject<List<UserAccount>>(json);
            }
            return accounts;
        }

        public static void Add(UserAccount user)
        {
            String myFile = "accounts.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                accounts = JsonConvert.DeserializeObject<List<UserAccount>>(json);
            }

            UserAccount newuser = user;

            accounts.Add(newuser);

            File.Delete(myFile);

            String jsonString;
            jsonString = JsonConvert.SerializeObject(accounts);

            using (var streamWriter = new StreamWriter(myFile, true))
            {
                streamWriter.WriteLine(jsonString);
            }

        }

        public static void Update(string username, UserAccount user)
        {
            String myFile = "accounts.txt";

            if (File.Exists(myFile))
            {
                string json = File.ReadAllText(myFile);
                accounts = JsonConvert.DeserializeObject<List<UserAccount>>(json);
            }


            foreach (UserAccount u in accounts)
            {
                if (u.username == username)
                {
                    u.firstname = user.firstname;
                    u.lastname = user.lastname;
                    u.username = user.username;
                    u.password = user.password;
                    u.customerOrWorker = user.customerOrWorker;
                    u.favorites = user.favorites;
                }
            }


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
