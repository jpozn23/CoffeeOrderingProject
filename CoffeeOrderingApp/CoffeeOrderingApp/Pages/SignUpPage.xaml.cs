using CoffeeOrderingApp.Classes;
using CoffeeOrderingApp.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeOrderingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        //readonly String serverURL = "https://10.0.1.218:8080"; // https may give ssl errors
        //readonly String serverURL = "http://192.168.1.13:8090";  //  // Change this to your real IP address.
        readonly String serverURL = "http://192.168.0.57:8090";  //  // Change this to your real IP address.

        private List<User> accounts = new List<User>();
        string customerOrWorker = "";

        public SignUpPage()
        {
            InitializeComponent();
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            customerOrWorker = (string)radioButton.Content;
        }

        private int ValidateInput()
        {
            // validate all fields are filled out
            if (String.IsNullOrEmpty(Firstname.Text) || String.IsNullOrEmpty(Lastname.Text) || String.IsNullOrEmpty(Username.Text)
                || String.IsNullOrEmpty(Password.Text) || String.IsNullOrEmpty(customerOrWorker))
            {
                return 1;
            }

            // validate password and confirm password fields are same
            if (Convert.ToString(Password.Text) != Convert.ToString(ConfirmPassword.Text))
            {
                return 2;
            }

            return 0;
        }

        private bool ValidateUsername(List<User> accounts)
        {
            // validate username does not already exist
            foreach (User user in accounts)
            {
                if (user.username == Convert.ToString(Username.Text))
                {
                    return false;
                }
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

        public async Task SaveAccount(User newuser)
        {
            HttpClient client;
            client = new HttpClient();
            var uri = new Uri(serverURL + "/api/Account");

            String jsonString = JsonConvert.SerializeObject(newuser);
            StringContent strContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, strContent);

            if (response.IsSuccessStatusCode)
            {
                // Singleton to pass user info
                Singletons.UserSingleton.Instance.username = newuser.username;
                Singletons.UserSingleton.Instance.password = newuser.password;
                Singletons.UserSingleton.Instance.firstname = newuser.firstname;
                Singletons.UserSingleton.Instance.lastname = newuser.lastname;
                Singletons.UserSingleton.Instance.customerOrWorker = newuser.customerOrWorker;
                Singletons.UserSingleton.Instance.favorites = newuser.favorites;
            }

        }


        
        async private void SignUpButton_Clicked(object sender, EventArgs e)
        {

            // Validate Inputs
            int errormsg = ValidateInput();
            if(errormsg == 1)
            {
                await DisplayAlert("Error", "Invalid Sign Up. All fields must be filled out.", "Ok");
                return;
            } else if (errormsg == 2)
            {
                await DisplayAlert("Error", "Invalid Sign Up. The password and confirm password fields must be the same .", "Ok");
                return;
            } else
            {
            }

            // Get Accounts
            List<User> accounts = await GetAccounts();

            // See if Username Exists
            bool validUsername = ValidateUsername(accounts);
            if(!validUsername)
            {
                await DisplayAlert("Error", "Username already exists.", "Ok");
                return;
            }

            // Save Account
            User newuser = new User();
            newuser.username = Convert.ToString(Username.Text);
            newuser.password = Convert.ToString(Password.Text);
            newuser.firstname = Convert.ToString(Firstname.Text);
            newuser.lastname = Convert.ToString(Lastname.Text);
            newuser.customerOrWorker = Convert.ToString(customerOrWorker);
            newuser.favorites = null;

            await SaveAccount(newuser);

            // Page to be displayed
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
}