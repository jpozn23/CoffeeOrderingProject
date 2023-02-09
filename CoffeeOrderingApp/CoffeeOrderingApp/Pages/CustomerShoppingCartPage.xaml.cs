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
    public partial class CustomerShoppingCartPage : ContentPage
    {
        public List<Order> orders = new List<Order>();
        public CustomerShoppingCartPage()
        {
            InitializeComponent();
        }

        private void DisplayDrinks()
        {
            List<Beverage> beverages = Singletons.OrderSingleton.Instance.beverages;

            int i = 0;
            foreach(Beverage b in beverages) {
                if(i == 0)
                {
                    Drink1NameLabel.Text = "Type: " + b.GetDrinkType() + " - " + b.GetDrinkSize();

                    if(b.GetAddSubs().Length >= 2)
                    {
                        String s = b.GetAddSubs();
                        s = s.Substring(1);
                        Drink1AddSubsLabel.Text = "Details: " + s;
                    } else
                    {
                        Drink1AddSubsLabel.Text = "Details: None ";
                    }
                    

                    Drink1TotalLabel.Text = "$ " + b.Cost().ToString();
                } else if (i == 1)
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
                } else if (i == 2)
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
                } else if (i == 3)
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
                } else if (i == 4)
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
                } else
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

                if(b.GetAddSubs().Length > 2)
                {
                    String s = b.GetAddSubs();
                    s = s.Substring(1);
                    d.addsubs = s;
                } else
                {
                    d.addsubs = "None";
                }
                

                order.beverages.Add(d);
            }
            return order;
        }

        private void WriteOrder(Order order)
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

            String myFile = "orders.txt";
            String pathFile = Path.Combine(userPath, myFile);

            // Read Orders From File
            if (File.Exists(pathFile))
            {
                string json = File.ReadAllText(pathFile);
                orders = JsonConvert.DeserializeObject<List<Order>>(json);
            }

            File.Delete(pathFile);

            orders.Add(order);

            // Write new order to file
            String jsonString;
            jsonString = JsonConvert.SerializeObject(orders);

            using (var streamWriter = new StreamWriter(pathFile, true))
            {
                streamWriter.WriteLine(jsonString);
            }

        }

        async private void CheckoutButton_Clicked(object sender, EventArgs e)
        {
            // Create Order 
            Order order = CreateOrder();

            // Write Order to file 
            WriteOrder(order);

            await DisplayAlert("Successful Order", "Your order will be ready in about 15 minutes.", "Ok");


            // Reset Singleton, Labels
            ResetVars();

            await Navigation.PushAsync(new CustomerHomePage());
        }

        async private void CancelButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Successful", "Your order has been removed.", "Ok");
            
            // Reset Singleton, Labels
            ResetVars();

            await Navigation.PushAsync(new CustomerHomePage());

        }
    }
}