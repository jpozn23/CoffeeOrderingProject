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
        async private void SignUpButton_Clicked(object sender, EventArgs e)
        {
            accounts.Clear();

            // Make sure all fields are filled out
            if (String.IsNullOrEmpty(Firstname.Text) || String.IsNullOrEmpty(Lastname.Text) || String.IsNullOrEmpty(Username.Text)
                || String.IsNullOrEmpty(Password.Text) || String.IsNullOrEmpty(customerOrWorker))
            {
                await DisplayAlert("Error", "Invalid Sign Up. All fields must be filled out.", "Ok");
                return;
            }

            // Make sure password and confirm password fields are equal
            if(Convert.ToString(Password.Text) != Convert.ToString(ConfirmPassword.Text)) {
                await DisplayAlert("Error", "Invalid Sign Up. The password and confirm password fields must be the same .", "Ok");
                return;
            }


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

            if (File.Exists(pathFile))
            {
                string json = File.ReadAllText(pathFile);
                accounts = JsonConvert.DeserializeObject<List<User>>(json);
            }


            foreach (User user in accounts)
            {
                if (user.username == Convert.ToString(Username.Text))
                {
                    await DisplayAlert("Error", "Username already exists.", "Ok");
                    return;
                }
            }

            File.Delete(pathFile);

            User newUser = new User();
            newUser.username = Convert.ToString(Username.Text);
            newUser.password = Convert.ToString(Password.Text);
            newUser.firstname = Convert.ToString(Firstname.Text);
            newUser.lastname = Convert.ToString(Lastname.Text);
            newUser.customerOrWorker = Convert.ToString(customerOrWorker);

            accounts.Add(newUser);

            String jsonString;
            jsonString = JsonConvert.SerializeObject(accounts);

            using (var streamWriter = new StreamWriter(pathFile, true))
            {
                streamWriter.WriteLine(jsonString);
            }

            Singletons.UserSingleton.Instance.username = newUser.username;
            Singletons.UserSingleton.Instance.password = newUser.password;
            Singletons.UserSingleton.Instance.firstname = newUser.firstname;
            Singletons.UserSingleton.Instance.lastname = newUser.lastname;
            Singletons.UserSingleton.Instance.customerOrWorker = newUser.customerOrWorker;

            if(newUser.customerOrWorker == "Customer")
            {
                await Navigation.PushAsync(new CustomerHomePage());
            } else
            {
                await Navigation.PushAsync(new WorkerHomePage());
            }
        }

    }
}