using CoffeeOrderingApp.Classes;
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

namespace CoffeeOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkerCurrentOrdersPage : ContentPage
    {
        //readonly String serverURL = "https://10.0.1.218:8080"; // https may give ssl errors
        readonly String serverURL = "http://192.168.1.13:8090";  //  // Change this to your real IP address.  
        //readonly String serverURL = "http://192.168.0.57:8090";  //  // Change this to your real IP address.  

        public List<Order> incompleteOrders = new List<Order>();

        public WorkerCurrentOrdersPage()
        {
            InitializeComponent();
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();

            // Make sure singleton list empty
            Singletons.WorkerOrdersSingleton.Instance.orders.Clear();
            incompleteOrders.Clear();

            // calls method to get all orders on file that have a completion status of FALSE
            List<Order> orders = await GetOrders();

            // get only incomplete orders
            foreach(Order o in orders)
            {
                if(o.isCompleted == false)
                {
                    incompleteOrders.Add(o);
                }
            }

            // sets current order labels and passes rest of orders to singleton which will be read from in WorkerOrderPage
            SetOrders();

        }

        private void SetOrders()
        {
            int num = 0;
            foreach (Order order in incompleteOrders)
            {
                // first item in incomplete orders list
                if (num == 0)
                {
                    CurrentDrinkOrderIDLabel.Text = order.id.ToString();
                    CurrentDrinkOrderNameLabel.Text = order.firstname;
                    CurrentDrinkOrderTimeLabel.Text = order.pickupTime.ToString();

                    if (order.drink1 != null)
                    {
                        CurrentDrink1TypeLabel.Text = "Type: " + order.drink1.drinkType;
                        CurrentDrink1SizeLabel.Text = "Size: " + order.drink1.drinkSize;
                        CurrentDrink1AddSubLabel.Text = "A/S: " + order.drink1.addsubs;
                    }
                    if (order.drink2 != null)
                    {
                        CurrentDrink2TypeLabel.Text = "Type: " + order.drink2.drinkType;
                        CurrentDrink2SizeLabel.Text = "Size: " + order.drink2.drinkSize;
                        CurrentDrink2AddSubLabel.Text = "A/S: " + order.drink2.addsubs;
                    }
                    if (order.drink3 != null)
                    {
                        CurrentDrink3TypeLabel.Text = "Type: " + order.drink3.drinkType;
                        CurrentDrink3SizeLabel.Text = "Size: " + order.drink3.drinkSize;
                        CurrentDrink3AddSubLabel.Text = "A/S: " + order.drink3.addsubs;
                    }
                    if (order.drink4 != null)
                    {
                        CurrentDrink4TypeLabel.Text = "Type: " + order.drink4.drinkType;
                        CurrentDrink4SizeLabel.Text = "Size: " + order.drink4.drinkSize;
                        CurrentDrink4AddSubLabel.Text = "A/S: " + order.drink4.addsubs;
                    }
                    if (order.drink5 != null)
                    {
                        CurrentDrink5TypeLabel.Text = "Type: " + order.drink5.drinkType;
                        CurrentDrink5SizeLabel.Text = "Size: " + order.drink5.drinkSize;
                        CurrentDrink5AddSubLabel.Text = "A/S: " + order.drink5.addsubs;
                    }
                }
                else
                {
                    Singletons.WorkerOrdersSingleton.Instance.orders.Add(order);
                }
                num++;
            }
        }


        public async Task<List<Order>> GetOrders()
        {
            HttpClient client;
            client = new HttpClient();
            var uri = new Uri(serverURL + "/api/Order");
            var response = await client.GetAsync(uri);
            List<Order> userOrders = null;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                userOrders = JsonConvert.DeserializeObject<List<Order>>(content);
            }
            return userOrders;
        }


        private void ResetVars()
        {
            CurrentDrinkOrderNameLabel.Text = "";
            CurrentDrinkOrderTimeLabel.Text = "";

            CurrentDrink1TypeLabel.Text = "";
            CurrentDrink1SizeLabel.Text = "";
            CurrentDrink1AddSubLabel.Text = "";

            CurrentDrink2TypeLabel.Text = "";
            CurrentDrink2SizeLabel.Text = "";
            CurrentDrink2AddSubLabel.Text = "";

            CurrentDrink3TypeLabel.Text = "";
            CurrentDrink3SizeLabel.Text = "";
            CurrentDrink3AddSubLabel.Text = "";

            CurrentDrink4TypeLabel.Text = "";
            CurrentDrink4SizeLabel.Text = "";
            CurrentDrink4AddSubLabel.Text = "";

            CurrentDrink5TypeLabel.Text = "";
            CurrentDrink5SizeLabel.Text = "";
            CurrentDrink5AddSubLabel.Text = "";
        }

        public async Task SaveCompletedOrder(Order completedOrder)
        {
            HttpClient client;
            client = new HttpClient();

            var uri = new Uri(serverURL + "/api/Order/" + completedOrder.userName + "/" + completedOrder.id.ToString());

            String jsonString = JsonConvert.SerializeObject(completedOrder);
            StringContent strContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(uri, strContent);

            if (response.IsSuccessStatusCode)
            {

            }

        }


        async private void CompleteOrderButton_Clicked(object sender, EventArgs e)
        {
            // Change current order isCompleted and Save
            int num = 0;
            foreach(Order order in incompleteOrders)
            {
                if(num == 0)
                {
                    // sets completion status of first order in list to true
                    order.isCompleted = true;
                    await SaveCompletedOrder(order);
                }
                num++;
            }


            incompleteOrders.Clear();

            ResetVars();

            await DisplayAlert("Successful", "The order has been successfully completed.", "Ok");

            // Make sure singleton list empty
            Singletons.WorkerOrdersSingleton.Instance.orders.Clear();


            // calls method to get all orders on file that have a completion status of FALSE
            List<Order> userOrders = await GetOrders();

            // get only incomplete orders
            foreach (Order o in userOrders)
            {
                if (o.isCompleted == false)
                {
                    incompleteOrders.Add(o);
                }
            }

            // sets current order labels and passes rest of orders to singleton which will be read from in WorkerOrderPage
            SetOrders();

        }

        async private void CancelOrderButton_Clicked(object sender, EventArgs e)
        {
            // Change current item isCompleted
            int num = 0;
            foreach (Order order in incompleteOrders)
            {
                if (num == 0)
                {
                    order.isCompleted = true;
                    await SaveCompletedOrder(order);
                }
                num++;
            }

            incompleteOrders.Clear();

            ResetVars();

            await DisplayAlert("Successful", "The order has been successfully cancelled.", "Ok");

            // Make sure singleton list empty
            Singletons.WorkerOrdersSingleton.Instance.orders.Clear();

            // calls method to get all orders on file that have a completion status of FALSE
            List<Order> userOrders = await GetOrders();

            // get only incomplete orders
            foreach (Order o in userOrders)
            {
                if (o.isCompleted == false)
                {
                    incompleteOrders.Add(o);
                }
            }

            // sets current order labels and passes rest of orders to singleton which will be read from in WorkerOrderPage
            SetOrders();
        }

        async private void ViewOrdersInQueueButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkerOrderQueuePage());
        }

        
    }
}