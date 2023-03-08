using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CoffeeOrderingApp.Classes;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerOrderHistoryPage : ContentPage
    {
        // Change this to your real IP address.  run ipconfig /all in a command prompt
        readonly String serverURL = "http://192.168.1.12:8090";


        List<Order> previousOrders = new List<Order>();
        String full_name = Singletons.UserSingleton.Instance.firstname + Singletons.UserSingleton.Instance.lastname;
        String userName = Singletons.UserSingleton.Instance.username;
        String firstName = Singletons.UserSingleton.Instance.firstname;
        String lastName = Singletons.UserSingleton.Instance.lastname;
        
        public CustomerOrderHistoryPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // get customer orders
            await GetCustomerOrders();

            // display those orders to ui
            DisplayPreviousOrders();
        }

        private void DisplayPreviousOrders()
        {
            int num = previousOrders.Count;

            if (previousOrders.Count >= 5)
            {
                foreach (Order order in previousOrders)
                {
                    // Start from back of the list and go to front to display in reversed order.
                    if (num == previousOrders.Count - 4 && num >= 0)
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

                    }
                    else if (num == previousOrders.Count - 3 && num >= 0)
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
                    }
                    else if (num == previousOrders.Count - 2 && num >= 0)
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
                    }
                    else if (num == previousOrders.Count - 1 && num >= 0)
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

                    }
                    else if (num == previousOrders.Count && num >= 0)
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

            } 
            else if ( previousOrders.Count == 4 ) // Only 4 items in the list.
            {
                foreach (Order order in previousOrders)
                {
                    // Start from back of the list and go to front to display in reversed order.
                    if (num == previousOrders.Count - 3 && num >= 0)
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

                    }
                    else if (num == previousOrders.Count - 2 && num >= 0)
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
                    }
                    else if (num == previousOrders.Count - 1 && num >= 0)
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
                    }
                    else if (num == previousOrders.Count && num >= 0)
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

                    }
                    num--;
                } // END OF FOREACH ORDER IN ORDERS LOOP

            } 
            else if ( previousOrders.Count == 3 ) // Only 3 items in the list
            {
                foreach (Order order in previousOrders)
                {
                    // Start from back of the list and go to front to display in reversed order.
                    if (num == previousOrders.Count - 2 && num >= 0)
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

                    }
                    else if (num == previousOrders.Count - 1 && num >= 0)
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
                    }
                    else if (num == previousOrders.Count && num >= 0)
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
                    }
                    num--;
                } // END OF FOREACH ORDER IN ORDERS LOOP

            } 
            else if ( previousOrders.Count == 2 ) // Only 2 items in the list.
            {

                // Display drinks of previous orders
                foreach (Order order in previousOrders)
                {
                    // Start from back of the list and go to front to display in reversed order.
                    if (num == previousOrders.Count - 1 && num >= 0)
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

                    }
                    else if (num == previousOrders.Count && num >= 0)
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
                    }
                    num--;
                } // END OF FOREACH ORDER IN ORDERS LOOP

            } 
            else if ( previousOrders.Count == 1 ) // Only 1 item in the list.
            {
                foreach (Order order in previousOrders)
                {
                    // Start from back of the list and go to front to display in reversed order.
                    if (num == previousOrders.Count && num >= 0)
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
                    } // END OF IF STATEMENT
                    num--;
                } // END OF FOREACH ORDER IN ORDERS LOOP

            } // END OF IF STATEMENT
        } // END OF DISPLAY ORDERS FUNCTION


        public async Task GetCustomerOrders()
        {
            previousOrders.Clear();

            HttpClient client;
            client = new HttpClient();
            var uri = new Uri(serverURL + "/api/Order/" + userName );
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                previousOrders = JsonConvert.DeserializeObject<List<Order>>(content);

                int i = 0;
                foreach (Order order in previousOrders)
                {
                    
                    if ( previousOrders[i].drink1 != null )
                    {
                        previousOrders[i].beverages.Add(previousOrders[i].drink1);
                    }                    
                    
                    if ( previousOrders[i].drink2 != null )
                    {
                        previousOrders[i].beverages.Add(previousOrders[i].drink2);
                    }                    
                    
                    if ( previousOrders[i].drink3 != null )
                    {
                        previousOrders[i].beverages.Add(previousOrders[i].drink3);
                    }                    
                    
                    if ( previousOrders[i].drink4 != null )
                    {
                        previousOrders[i].beverages.Add(previousOrders[i].drink4);
                    }                    
                    
                    if ( previousOrders[i].drink5 != null )
                    {
                        previousOrders[i].beverages.Add(previousOrders[i].drink5);
                    }

                    i++;
                    
                } // END OF FOR-EACH LOOP
            } // END OF IF STATEMENT
        } // END OF FUNCTION

        /*private void GetCustomerOrders()
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

        }*///END OF FUNCTION

    } // END OF CLASS

} // END OF NAMESPACE