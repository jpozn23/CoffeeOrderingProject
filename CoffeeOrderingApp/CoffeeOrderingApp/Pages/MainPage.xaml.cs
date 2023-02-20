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
        private List<User> accounts = new List<User>();
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

        
        /*
        public async Task<List<User>> GetAccountsAsync()
        {
            HttpClient client;
            client = new HttpClient();
            var uri = new Uri("https://golfapi1.azurewebsites.net/api/Golf/" + username + "/" + coursename);
            var response = await client.GetAsync(uri);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                accounts = JsonConvert.DeserializeObject<List<User>>(content);
            }

            return accounts;
        }

        */
        
        

        private void GetAccounts()
        {
            // Get File Path
            String userPath = "";
            if (Device.RuntimePlatform == Device.Android)
            {
                userPath = App.PlatformSpecific.GetPublicStoragePath();
            }
            else
            {
                userPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            }

            String myFile = "userAccounts.txt";
            String pathFile = Path.Combine(userPath, myFile);

            // Read Accounts From File
            if (File.Exists(pathFile))
            {
                string json = File.ReadAllText(pathFile);
                accounts = JsonConvert.DeserializeObject<List<User>>(json);
            }
        }

       
        private bool ValidateAccount()
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
                    //Singletons.UserSingleton.Instance.favorites = user.favorites;

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
            GetAccounts();
            //await GetAccountsAsync();

            // Validate Account
            bool validateAccount = ValidateAccount();
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
