using CoffeeOrderingApp.Classes;
using CoffeeOrderingApp.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoffeeOrderingApp
{
    public partial class MainPage : ContentPage
    {
        //readonly String serverURL = "https://10.0.1.218:8080"; // https may give ssl errors
        readonly String serverURL = "http://192.168.1.13:8090";  //  // Change this to your real IP address.  

        public MainPage()
        {
            InitializeComponent();
        }

        private bool ValidateInput()
        {
            if (String.IsNullOrEmpty(Username.Text) || String.IsNullOrEmpty(Password.Text))
            {
                return false;
            }
            return true;
        }



        public async Task<List<User>> GetAccounts()
        {
            HttpClient client;
            client = new HttpClient();
            var uri = new Uri(serverURL + "/api/Account");
            var response = await client.GetAsync(uri);
            List<User> userAccounts = null;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                userAccounts = JsonConvert.DeserializeObject<List<User>>(content);
            }
            return userAccounts;
        }

       
        private bool ValidateAccount(List<User> accounts)
        {
            // Validate if account exists
            foreach (User user in accounts)
            {
                if (user.username.Equals(Convert.ToString(Username.Text)) && user.password.Equals(Convert.ToString(Password.Text)))
                {
                    // Set Singleton To Pass User Info
                    Singletons.UserSingleton.Instance.username = user.username;
                    Singletons.UserSingleton.Instance.password = user.password;
                    Singletons.UserSingleton.Instance.firstname = user.firstname;
                    Singletons.UserSingleton.Instance.lastname = user.lastname;
                    Singletons.UserSingleton.Instance.customerOrWorker = user.customerOrWorker;
                    Singletons.UserSingleton.Instance.favorites = user.favorites;
                    Singletons.UserSingleton.Instance.favdrink1= user.favdrink1;
                    Singletons.UserSingleton.Instance.favdrink2 = user.favdrink2;
                    Singletons.UserSingleton.Instance.favdrink3 = user.favdrink3;
                    Singletons.UserSingleton.Instance.favdrink4 = user.favdrink4;
                    Singletons.UserSingleton.Instance.favdrink5 = user.favdrink5;

                    return true;
                }
            }
            return false;
        }

        async private void LogInButton_Clicked(object sender, EventArgs e)
        {
            // Validate Input
            bool validate = ValidateInput();
            if(!validate)
            {
                await DisplayAlert("Error", "Invalid Login. All fields must be filled out.", "Ok");
                return;
            }

            // Get Accounts
            List<User> accounts = await GetAccounts();

            // Validate Account
            bool validateAccount = ValidateAccount(accounts);
            if(!validateAccount)
            {
                await DisplayAlert("Error", "Invalid Login. Try again", "Ok");
                return;
            } else
            {
                // Push Page
                if (Singletons.UserSingleton.Instance.customerOrWorker == "Customer")
                {
                    await Navigation.PushAsync(new CustomerHomePage());
                }
                else
                {
                    await Navigation.PushAsync(new WorkerHomePage());
                }
            }
        }

        async private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async private void ViewMenuButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MenuPage());
        }
    }
}
