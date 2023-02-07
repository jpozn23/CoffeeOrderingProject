using CoffeeOrderingApp.Classes;
using CoffeeOrderingApp.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

        async private void LogInButton_Clicked(object sender, EventArgs e)
        {
            // Check if they filled in all fields

            if (String.IsNullOrEmpty(Username.Text) || String.IsNullOrEmpty(Password.Text))
            {
                await DisplayAlert("Error", "Invalid Login. All fields must be filled out.", "Ok");
                return;
            }

            // Read from file

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

            Console.WriteLine(pathFile);

            if (File.Exists(pathFile))
            {
                string json = File.ReadAllText(pathFile);
                accounts = JsonConvert.DeserializeObject<List<User>>(json);
            }

            // Make sure they have an account

            bool loggedin = false;
            string customerOrWorker = "";
            foreach (User user in accounts)
            {
                if (user.username == Convert.ToString(Username.Text) && user.password == Convert.ToString(Password.Text))
                {
                    Singletons.UserSingleton.Instance.username = user.username;
                    Singletons.UserSingleton.Instance.password = user.password;
                    Singletons.UserSingleton.Instance.firstname = user.firstname;
                    Singletons.UserSingleton.Instance.lastname = user.lastname;
                    Singletons.UserSingleton.Instance.customerOrWorker = user.customerOrWorker;
                    customerOrWorker = user.customerOrWorker;
                    loggedin = true;
                }
            }
            if (loggedin == true)
            {
                if(customerOrWorker == "Customer")
                {
                    await Navigation.PushAsync(new CustomerHomePage());
                } else
                {
                    await Navigation.PushAsync(new WorkerHomePage());
                }
            }
            else
            {
                await DisplayAlert("Error", "Invalid Login, Try again", "Ok");
                return;
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
