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
    public partial class CustomerShoppingCartPage : ContentPage
    {
        //readonly String serverURL = "https://10.0.1.218:8080"; // https may give ssl errors
        readonly String serverURL = "http://192.168.1.13:8090";  //  // Change this to your real IP address.  
        //readonly String serverURL = "http://192.168.0.57:8090";  //  // Change this to your real IP address.  


        public CustomerShoppingCartPage()
        {
            InitializeComponent();
        }

        private void DisplayDrinks()
        {
            List<Beverage> beverages = Singletons.OrderSingleton.Instance.beverages;

            int i = 0;
            foreach (Beverage b in beverages)
            {
                if (i == 0)
                {
                    Drink1NameLabel.Text = "Type: " + b.GetDrinkType() + " - " + b.GetDrinkSize();

                    if (b.GetAddSubs().Length >= 2)
                    {
                        String s = b.GetAddSubs();
                        s = s.Substring(1);
                        Drink1AddSubsLabel.Text = "Details: " + s;
                    }
                    else
                    {
                        Drink1AddSubsLabel.Text = "Details: None ";
                    }


                    Drink1TotalLabel.Text = "$ " + b.Cost().ToString();
                }
                else if (i == 1)
                {
                    Drink2NameLabel.Text = "Type: " + b.GetDrinkType() + " -  " + b.GetDrinkSize();

                    if (b.GetAddSubs().Length >= 2)
                    {
                        String s = b.GetAddSubs();
                        s = s.Substring(1);
                        Drink2AddSubsLabel.Text = "Details: " + s;
                    }
                    else
                    {
                        Drink2AddSubsLabel.Text = "Details: None ";
                    }

                    Drink2TotalLabel.Text = "$ " + b.Cost().ToString();
                }
                else if (i == 2)
                {
                    Drink3NameLabel.Text = "Type: " + b.GetDrinkType() + " - " + b.GetDrinkSize();

                    if (b.GetAddSubs().Length >= 2)
                    {
                        String s = b.GetAddSubs();
                        s = s.Substring(1);
                        Drink3AddSubsLabel.Text = "Details: " + s;
                    }
                    else
                    {
                        Drink3AddSubsLabel.Text = "Details: None ";
                    }

                    Drink3TotalLabel.Text = "$ " + b.Cost().ToString();
                }
                else if (i == 3)
                {
                    Drink4NameLabel.Text = "Type: " + b.GetDrinkType() + " - " + b.GetDrinkSize();

                    if (b.GetAddSubs().Length >= 2)
                    {
                        String s = b.GetAddSubs();
                        s = s.Substring(1);
                        Drink4AddSubsLabel.Text = "Details: " + s;
                    }
                    else
                    {
                        Drink4AddSubsLabel.Text = "Details: None ";
                    }

                    Drink4TotalLabel.Text = "$ " + b.Cost().ToString();
                }
                else if (i == 4)
                {
                    Drink5NameLabel.Text = "Type: " + b.GetDrinkType() + " - " + b.GetDrinkSize();

                    if (b.GetAddSubs().Length >= 2)
                    {
                        String s = b.GetAddSubs();
                        s = s.Substring(1);
                        Drink5AddSubsLabel.Text = "Details: " + s;
                    }
                    else
                    {
                        Drink5AddSubsLabel.Text = "Details: None ";
                    }

                    Drink5TotalLabel.Text = "$ " + b.Cost().ToString();
                }
                else
                {

                }

                i++;
            }
        }
        private void DisplayTotal()
        {
            double total = 0;
            foreach (Beverage b in Singletons.OrderSingleton.Instance.beverages)
            {
                total = total + b.Cost();
            }
            total = total * 1.06;
            TotalOrderPriceLabel.Text = String.Format("{0:0.00}", total);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            DisplayDrinks();

            DisplayTotal();

        }

        private void ResetVars()
        {
            // Reset Singleton, Labels
            List<Beverage> newlist = new List<Beverage>();
            Singletons.OrderSingleton.Instance.beverages = newlist;
            Singletons.OrderSingleton.Instance.drink1 = null;
            Singletons.OrderSingleton.Instance.drink2 = null;
            Singletons.OrderSingleton.Instance.drink3 = null;
            Singletons.OrderSingleton.Instance.drink4 = null;
            Singletons.OrderSingleton.Instance.drink5 = null;

            Drink1NameLabel.Text = "";
            Drink1AddSubsLabel.Text = "";
            Drink1TotalLabel.Text = "";
            Drink2NameLabel.Text = "";
            Drink2AddSubsLabel.Text = "";
            Drink2TotalLabel.Text = "";
            Drink3NameLabel.Text = "";
            Drink3AddSubsLabel.Text = "";
            Drink3TotalLabel.Text = "";
            Drink4NameLabel.Text = "";
            Drink4AddSubsLabel.Text = "";
            Drink4TotalLabel.Text = "";
            Drink5NameLabel.Text = "";
            Drink5AddSubsLabel.Text = "";
            Drink5TotalLabel.Text = "";
            TotalOrderPriceLabel.Text = "";
        }

        private Order CreateOrder()
        {
            Order order = new Order();
            order.id = Guid.NewGuid();
            order.userName = Singletons.UserSingleton.Instance.username;
            order.firstname = Singletons.UserSingleton.Instance.firstname;
            order.isCompleted = false;

            string dt1 = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            DateTime dt2 = DateTime.Parse(dt1);
            DateTime dt3 = dt2.AddMinutes(15);
            order.pickupTime = dt3;

            foreach (Beverage b in Singletons.OrderSingleton.Instance.beverages)
            {
                Drink d = new Drink();
                d.drinkType = b.GetDrinkType();
                d.cost = b.Cost();
                d.drinkSize = b.GetDrinkSize();

                if (b.GetAddSubs().Length > 2)
                {
                    String s = b.GetAddSubs();
                    s = s.Substring(1);
                    d.addsubs = s;
                }
                else
                {
                    d.addsubs = "None";
                }

                order.beverages.Add(d);

                if (Singletons.OrderSingleton.Instance.drink1 == null)
                {
                    Singletons.OrderSingleton.Instance.drink1 = d;
                }
                else if (Singletons.OrderSingleton.Instance.drink2 == null)
                {
                    Singletons.OrderSingleton.Instance.drink2 = d;
                }
                else if (Singletons.OrderSingleton.Instance.drink3 == null)
                {
                    Singletons.OrderSingleton.Instance.drink3 = d;
                }
                else if (Singletons.OrderSingleton.Instance.drink4 == null)
                {
                    Singletons.OrderSingleton.Instance.drink4 = d;
                }
                else
                {
                    Singletons.OrderSingleton.Instance.drink5 = d;
                }

            }

            order.drink1 = Singletons.OrderSingleton.Instance.drink1;
            order.drink2 = Singletons.OrderSingleton.Instance.drink2;
            order.drink3 = Singletons.OrderSingleton.Instance.drink3;
            order.drink4 = Singletons.OrderSingleton.Instance.drink4;
            order.drink5 = Singletons.OrderSingleton.Instance.drink5;

            return order;
        }

        public async Task SaveOrder(Order neworder)
        {
            HttpClient client;
            client = new HttpClient();
            var uri = new Uri(serverURL + "/api/Order");

            String jsonString = JsonConvert.SerializeObject(neworder);
            StringContent strContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, strContent);

            if (response.IsSuccessStatusCode)
            {
                
            }

        }



        async private void CheckoutButton_Clicked(object sender, EventArgs e)
        {
            // Check to make sure cart not empty
            if (Singletons.OrderSingleton.Instance.beverages.Count <= 0)
            {
                await DisplayAlert("Error", "There are currently no items in your cart.", "Ok");
                return;
            }


            // Create Order 
            Order order = CreateOrder();

            // Write Order to file 
            await SaveOrder(order);
            

            await DisplayAlert("Successful Order", "Your order will be ready in about 15 minutes.", "Ok");


            // Reset Singleton, Labels
            ResetVars();

            await Navigation.PushAsync(new CustomerHomePage());
        }

        async private void CancelButton_Clicked(object sender, EventArgs e)
        {
            // Check to make sure cart not empty
            if (Singletons.OrderSingleton.Instance.beverages.Count <= 0)
            {
                await DisplayAlert("Error", "There are currently no items in your cart.", "Ok");
                return;
            }
            else
            {
                await DisplayAlert("Successful", "Your order has been removed.", "Ok");
            }

            // Reset Singleton, Labels
            ResetVars();

            await Navigation.PushAsync(new CustomerHomePage());

        }
    }
}