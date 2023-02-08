using CoffeeOrderingApp.Classes;
using CoffeeOrderingApp.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeOrderingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
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

        private void GetAccounts()
        {
            accounts.Clear();

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

            // Get accounts
            if (File.Exists(pathFile))
            {
                string json = File.ReadAllText(pathFile);
                accounts = JsonConvert.DeserializeObject<List<User>>(json);
            }
        }

        private bool ValidateUsername()
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

        private void UpdateFile()
        {
            // File Path
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

            File.Delete(pathFile);

            // New User Set
            User newUser = new User();
            newUser.username = Convert.ToString(Username.Text);
            newUser.password = Convert.ToString(Password.Text);
            newUser.firstname = Convert.ToString(Firstname.Text);
            newUser.lastname = Convert.ToString(Lastname.Text);
            newUser.customerOrWorker = Convert.ToString(customerOrWorker);

            accounts.Add(newUser);

            // Write new user to file
            String jsonString;
            jsonString = JsonConvert.SerializeObject(accounts);

            using (var streamWriter = new StreamWriter(pathFile, true))
            {
                streamWriter.WriteLine(jsonString);
            }

            // Set singleton to pass user info
            Singletons.UserSingleton.Instance.username = newUser.username;
            Singletons.UserSingleton.Instance.password = newUser.password;
            Singletons.UserSingleton.Instance.firstname = newUser.firstname;
            Singletons.UserSingleton.Instance.lastname = newUser.lastname;
            Singletons.UserSingleton.Instance.customerOrWorker = newUser.customerOrWorker;

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
            GetAccounts();

            // See if Username Exists
            bool validUsername = ValidateUsername();
            if(!validUsername)
            {
                await DisplayAlert("Error", "Username already exists.", "Ok");
                return;
            }

            // Write New Account To File, Update
            UpdateFile();

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