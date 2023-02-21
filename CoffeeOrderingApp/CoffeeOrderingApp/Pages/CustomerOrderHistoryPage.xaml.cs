using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CoffeeOrderingApp.Classes;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerOrderHistoryPage : ContentPage
    {
        List<Order> previousOrders = new List<Order>();
        String full_name = Singletons.UserSingleton.Instance.firstname + Singletons.UserSingleton.Instance.lastname;
        String firstName = Singletons.UserSingleton.Instance.firstname;
        String lastName = Singletons.UserSingleton.Instance.lastname;
        
        public CustomerOrderHistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetCustomerOrders();

            DisplayPreviousOrders();
        }

        private void DisplayPreviousOrders()
        {
            int num = previousOrders.Count;

            foreach (Order order in previousOrders)
            {
                // first item in list so set current order labels
                if ( num == previousOrders.Count-4 && num >= 0 )
                {
                    int i = 0;
                    foreach (Drink d in order.beverages)
                    {
                        if (i == 0)
                        {
                            Order1PreviousDrink1TypeLabel.Text = "Type: " + d.drinkType;
                            Order1PreviousDrink1SizeLabel.Text = "Size: " + d.drinkSize;
                            Order1PreviousDrink1AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 1)
                        {
                            Order1PreviousDrink2TypeLabel.Text = "Type: " + d.drinkType;
                            Order1PreviousDrink2SizeLabel.Text = "Size: " + d.drinkSize;
                            Order1PreviousDrink2AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 2)
                        {
                            Order1PreviousDrink3TypeLabel.Text = "Type: " + d.drinkType;
                            Order1PreviousDrink3SizeLabel.Text = "Size: " + d.drinkSize;
                            Order1PreviousDrink3AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 3)
                        {
                            Order1PreviousDrink4TypeLabel.Text = "Type: " + d.drinkType;
                            Order1PreviousDrink4SizeLabel.Text = "Size: " + d.drinkSize;
                            Order1PreviousDrink4AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 4)
                        {
                            Order1PreviousDrink5TypeLabel.Text = "Type: " + d.drinkType;
                            Order1PreviousDrink5SizeLabel.Text = "Size: " + d.drinkSize;
                            Order1PreviousDrink5AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        i++;
                    }

                } else if ( num == previousOrders.Count-3 && num >= 0 )
                {
                    int i = 0;
                    foreach (Drink d in order.beverages)
                    {
                        if (i == 0)
                        {
                            Order2PreviousDrink1TypeLabel.Text = "Type: " + d.drinkType;
                            Order2PreviousDrink1SizeLabel.Text = "Size: " + d.drinkSize;
                            Order2PreviousDrink1AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 1)
                        {
                            Order2PreviousDrink2TypeLabel.Text = "Type: " + d.drinkType;
                            Order2PreviousDrink2SizeLabel.Text = "Size: " + d.drinkSize;
                            Order2PreviousDrink2AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 2)
                        {
                            Order2PreviousDrink3TypeLabel.Text = "Type: " + d.drinkType;
                            Order2PreviousDrink3SizeLabel.Text = "Size: " + d.drinkSize;
                            Order2PreviousDrink3AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 3)
                        {
                            Order2PreviousDrink4TypeLabel.Text = "Type: " + d.drinkType;
                            Order2PreviousDrink4SizeLabel.Text = "Size: " + d.drinkSize;
                            Order2PreviousDrink4AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 4)
                        {
                            Order2PreviousDrink5TypeLabel.Text = "Type: " + d.drinkType;
                            Order2PreviousDrink5SizeLabel.Text = "Size: " + d.drinkSize;
                            Order2PreviousDrink5AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        i++;
                    }
                } else if ( num == previousOrders.Count-2 && num >= 0)
                {
                    int i = 0;
                    foreach (Drink d in order.beverages)
                    {
                        if (i == 0)
                        {
                            Order3PreviousDrink1TypeLabel.Text = "Type: " + d.drinkType;
                            Order3PreviousDrink1SizeLabel.Text = "Size: " + d.drinkSize;
                            Order3PreviousDrink1AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 1)
                        {
                            Order3PreviousDrink2TypeLabel.Text = "Type: " + d.drinkType;
                            Order3PreviousDrink2SizeLabel.Text = "Size: " + d.drinkSize;
                            Order3PreviousDrink2AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 2)
                        {
                            Order3PreviousDrink3TypeLabel.Text = "Type: " + d.drinkType;
                            Order3PreviousDrink3SizeLabel.Text = "Size: " + d.drinkSize;
                            Order3PreviousDrink3AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 3)
                        {
                            Order3PreviousDrink4TypeLabel.Text = "Type: " + d.drinkType;
                            Order3PreviousDrink4SizeLabel.Text = "Size: " + d.drinkSize;
                            Order3PreviousDrink4AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 4)
                        {
                            Order3PreviousDrink5TypeLabel.Text = "Type: " + d.drinkType;
                            Order3PreviousDrink5SizeLabel.Text = "Size: " + d.drinkSize;
                            Order3PreviousDrink5AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        i++;
                    }
                } else if ( num == previousOrders.Count-1 && num >= 0)
                {
                    int i = 0;
                    foreach (Drink d in order.beverages)
                    {
                        if (i == 0)
                        {
                            Order4PreviousDrink1TypeLabel.Text = "Type: " + d.drinkType;
                            Order4PreviousDrink1SizeLabel.Text = "Size: " + d.drinkSize;
                            Order4PreviousDrink1AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 1)
                        {
                            Order4PreviousDrink2TypeLabel.Text = "Type: " + d.drinkType;
                            Order4PreviousDrink2SizeLabel.Text = "Size: " + d.drinkSize;
                            Order4PreviousDrink2AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 2)
                        {
                            Order4PreviousDrink3TypeLabel.Text = "Type: " + d.drinkType;
                            Order4PreviousDrink3SizeLabel.Text = "Size: " + d.drinkSize;
                            Order4PreviousDrink3AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 3)
                        {
                            Order4PreviousDrink4TypeLabel.Text = "Type: " + d.drinkType;
                            Order4PreviousDrink4SizeLabel.Text = "Size: " + d.drinkSize;
                            Order4PreviousDrink4AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 4)
                        {
                            Order4PreviousDrink5TypeLabel.Text = "Type: " + d.drinkType;
                            Order4PreviousDrink5SizeLabel.Text = "Size: " + d.drinkSize;
                            Order4PreviousDrink5AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        i++;
                    }

                } else if ( num == previousOrders.Count && num >= 0)
                {
                    int i = 0;
                    foreach (Drink d in order.beverages)
                    {
                        if (i == 0)
                        {
                            Order5PreviousDrink1TypeLabel.Text = "Type: " + d.drinkType;
                            Order5PreviousDrink1SizeLabel.Text = "Size: " + d.drinkSize;
                            Order5PreviousDrink1AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 1)
                        {
                            Order5PreviousDrink2TypeLabel.Text = "Type: " + d.drinkType;
                            Order5PreviousDrink2SizeLabel.Text = "Size: " + d.drinkSize;
                            Order5PreviousDrink2AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 2)
                        {
                            Order5PreviousDrink3TypeLabel.Text = "Type: " + d.drinkType;
                            Order5PreviousDrink3SizeLabel.Text = "Size: " + d.drinkSize;
                            Order5PreviousDrink3AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 3)
                        {
                            Order5PreviousDrink4TypeLabel.Text = "Type: " + d.drinkType;
                            Order5PreviousDrink4SizeLabel.Text = "Size: " + d.drinkSize;
                            Order5PreviousDrink4AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        else if (i == 4)
                        {
                            Order5PreviousDrink5TypeLabel.Text = "Type: " + d.drinkType;
                            Order5PreviousDrink5SizeLabel.Text = "Size: " + d.drinkSize;
                            Order5PreviousDrink5AddSubLabel.Text = "A/S: " + d.addsubs;
                        }
                        i++;
                    } // END OF FOREACH DRINK IN ORDER.BEVERAGES LOOP
                } // END OF IF STATEMENT
                num--;
            } // END OF FOREACH ORDER IN ORDERS LOOP
        } // END OF DISPLAY ORDERS FUNCTION

        private void GetCustomerOrders()
        {
            previousOrders.Clear();

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

            // get orders that are from this particular user
            foreach (Order order in orders)
            {
                if (order.firstname == firstName)
                {
                    previousOrders.Add(order);
                }
            }

            // Not sure if need to sort actually bc orders are written to file in order
            // Just have to make sure write back to file in same order and not reverse
            // incompleteOrders.OrderBy(o => o.pickupTime);

        }
    } // END OF CLASS
}