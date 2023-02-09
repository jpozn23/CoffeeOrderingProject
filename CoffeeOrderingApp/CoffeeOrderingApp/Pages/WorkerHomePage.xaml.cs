using CoffeeOrderingApp.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkerHomePage : ContentPage
    {
        public List<Order> incompleteOrders = new List<Order>();
        public WorkerHomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Show Worker Name
            NameLabel.Text = Singletons.UserSingleton.Instance.firstname;

            // Make sure singleton list empty
            Singletons.WorkerOrdersSingleton.Instance.orders.Clear();

            // calls method to get all orders on file that have a completion status of FALSE
            GetOrders();

            // sets current order labels and passes rest of orders to singleton which will be read from in WorkerOrderPage
            SetOrders();


        }

        private void SetOrders()
        {
            int num = 0;
            foreach(Order order in incompleteOrders)
            {
                // first item in list so set current order labels
                if(num == 0)
                {
                    CurrentDrinkOrderNameLabel.Text = order.firstname;
                    CurrentDrinkOrderTimeLabel.Text = order.pickupTime.ToString();

                    // So all drinks in order all visible
                    int i = 0;
                    foreach(Drink d in order.beverages)
                    {
                        if(i == 0)
                        {
                            CurrentDrink1TypeLabel.Text = "Type: " + d.drinkType;
                            CurrentDrink1SizeLabel.Text = "Size: " + d.drinkSize;
                            CurrentDrink1AddSubLabel.Text = "A/S: " + d.addsubs;
                        } else if (i == 1)
                        {
                            CurrentDrink2TypeLabel.Text = "Type: " + d.drinkType;
                            CurrentDrink2SizeLabel.Text = "Size: " + d.drinkSize;
                            CurrentDrink2AddSubLabel.Text = "A/S: " + d.addsubs;
                        } else if (i == 2)
                        {
                            CurrentDrink3TypeLabel.Text = "Type: " + d.drinkType;
                            CurrentDrink3SizeLabel.Text = "Size: " + d.drinkSize;
                            CurrentDrink3AddSubLabel.Text = "A/S: " + d.addsubs;
                        } else if (i == 3)
                        {
                            CurrentDrink4TypeLabel.Text = "Type: " + d.drinkType;
                            CurrentDrink4SizeLabel.Text = "Size: " + d.drinkSize;
                            CurrentDrink4AddSubLabel.Text = "A/S: " + d.addsubs;
                        } else if (i == 4)
                        {
                            CurrentDrink5TypeLabel.Text = "Type: " + d.drinkType;
                            CurrentDrink5SizeLabel.Text = "Size: " + d.drinkSize;
                            CurrentDrink5AddSubLabel.Text = "A/S: " + d.addsubs;
                        } else
                        {

                        }
                        i++;
                    }
                } else
                {
                    Singletons.WorkerOrdersSingleton.Instance.orders.Add(order);
                }
                num++;
            }
        }

        private void GetOrders()
        {
            incompleteOrders.Clear();

            // Get File Path
            string userPath;
            if (Device.RuntimePlatform == Device.Android)
            {
                userPath = App.PlatformSpecific.GetPublicStoragePath();
            }
            else
            {
                userPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            }

            String myFile = "orders.txt";
            String pathFile = Path.Combine(userPath, myFile);

            List<Order> orders = new List<Order>();

            // read orders from file
            if (File.Exists(pathFile))
            {
                string json = File.ReadAllText(pathFile);
                orders = JsonConvert.DeserializeObject<List<Order>>(json);
            }

            // get orders that are incomplete
            foreach(Order order in orders)
            {
                if(order.isCompleted == false)
                {
                    incompleteOrders.Add(order);
                }
            }

            // Not sure if need to sort actually bc orders are written to file in order
            // Just have to make sure write back to file in same order and not reverse
            // incompleteOrders.OrderBy(o => o.pickupTime);



        }


        private void CompleteOrderButton_Clicked(object sender, EventArgs e)
        {

        }

        private void CancelOrderButton_Clicked(object sender, EventArgs e)
        {

        }

        async private void ViewOrdersInQueueButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkerOrderPage());
        }

        async private void LogOutButtonButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}