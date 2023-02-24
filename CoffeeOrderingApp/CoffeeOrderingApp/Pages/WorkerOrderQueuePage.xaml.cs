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
    public partial class WorkerOrderQueuePage : ContentPage
    {
        public List<Order> orders = new List<Order>();

        public WorkerOrderQueuePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ResetVars();

            // calls method to get all orders on file that have a completion status of FALSE
            SetLabels();
        }

        private void ResetVars()
        {
            OLOrder1TimeLabel.Text = "";
            OLOrder1NameLabel.Text = "";
            OLOrder1NumDrinksLabel.Text = "";
            OLOrder1TotalLabel.Text = "";

            OLOrder2TimeLabel.Text = "";
            OLOrder2NameLabel.Text = "";
            OLOrder2NumDrinksLabel.Text = "";
            OLOrder2TotalLabel.Text = "";

            OLOrder3TimeLabel.Text = "";
            OLOrder3NameLabel.Text = "";
            OLOrder3NumDrinksLabel.Text = "";
            OLOrder3TotalLabel.Text = "";

            OLOrder4TimeLabel.Text = "";
            OLOrder4NameLabel.Text = "";
            OLOrder4NumDrinksLabel.Text = "";
            OLOrder4TotalLabel.Text = "";

            OLOrder5TimeLabel.Text = "";
            OLOrder5NameLabel.Text = "";
            OLOrder5NumDrinksLabel.Text = "";
            OLOrder5TotalLabel.Text = "";

            OLOrder6TimeLabel.Text = "";
            OLOrder6NameLabel.Text = "";
            OLOrder6NumDrinksLabel.Text = "";
            OLOrder6TotalLabel.Text = "";

            OLOrder7TimeLabel.Text = "";
            OLOrder7NameLabel.Text = "";
            OLOrder7NumDrinksLabel.Text = "";
            OLOrder7TotalLabel.Text = "";

            OLOrder8TimeLabel.Text = "";
            OLOrder8NameLabel.Text = "";
            OLOrder8NumDrinksLabel.Text = "";
            OLOrder8TotalLabel.Text = "";

            OLOrder9TimeLabel.Text = "";
            OLOrder9NameLabel.Text = "";
            OLOrder9NumDrinksLabel.Text = "";
            OLOrder9TotalLabel.Text = "";

            OLOrder10TimeLabel.Text = "";
            OLOrder10NameLabel.Text = "";
            OLOrder10NumDrinksLabel.Text = "";
            OLOrder10TotalLabel.Text = "";
        }

        private void SetLabels()
        {
            int num = 0;
            foreach(Order o in Singletons.WorkerOrdersSingleton.Instance.orders)
            {
                if(num == 0)
                {
                    OLOrder1IDLabel.Text = o.id.ToString();
                    OLOrder1TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder1NameLabel.Text = o.firstname;
                    OLOrder1NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    int numDrinks = 0;
                    if(o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks++;
                    }
                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks++;
                    }
                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks++;
                    }
                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks++;
                    }
                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks++;
                    }


                    OLOrder1TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    OLOrder1NumDrinksLabel.Text = numDrinks.ToString();
                } else if(num == 1)
                {
                    OLOrder2IDLabel.Text = o.id.ToString();
                    OLOrder2TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder2NameLabel.Text = o.firstname;
                    OLOrder2NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks++;
                    }
                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks++;
                    }
                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks++;
                    }
                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks++;
                    }
                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks++;
                    }


                    OLOrder2TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    OLOrder2NumDrinksLabel.Text = numDrinks.ToString();
                } else if(num == 2)
                {
                    OLOrder3IDLabel.Text = o.id.ToString();
                    OLOrder3TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder3NameLabel.Text = o.firstname;
                    OLOrder3NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks++;
                    }
                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks++;
                    }
                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks++;
                    }
                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks++;
                    }
                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks++;
                    }


                    OLOrder3TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    OLOrder3NumDrinksLabel.Text = numDrinks.ToString();
                } else if (num == 3)
                {
                    OLOrder4IDLabel.Text = o.id.ToString();
                    OLOrder4TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder4NameLabel.Text = o.firstname;
                    OLOrder4NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks++;
                    }
                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks++;
                    }
                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks++;
                    }
                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks++;
                    }
                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks++;
                    }


                    OLOrder4TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    OLOrder4NumDrinksLabel.Text = numDrinks.ToString();
                } else if (num == 4)
                {
                    OLOrder5IDLabel.Text = o.id.ToString();
                    OLOrder5TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder5NameLabel.Text = o.firstname;
                    OLOrder5NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks++;
                    }
                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks++;
                    }
                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks++;
                    }
                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks++;
                    }
                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks++;
                    }


                    OLOrder5TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    OLOrder5NumDrinksLabel.Text = numDrinks.ToString();
                } else if (num == 5)
                {
                    OLOrder6IDLabel.Text = o.id.ToString();
                    OLOrder6TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder6NameLabel.Text = o.firstname;
                    OLOrder6NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks++;
                    }
                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks++;
                    }
                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks++;
                    }
                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks++;
                    }
                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks++;
                    }


                    OLOrder6TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    OLOrder6NumDrinksLabel.Text = numDrinks.ToString();
                } else if (num == 6)
                {
                    OLOrder7IDLabel.Text = o.id.ToString();
                    OLOrder7TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder7NameLabel.Text = o.firstname;
                    OLOrder7NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks++;
                    }
                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks++;
                    }
                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks++;
                    }
                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks++;
                    }
                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks++;
                    }


                    OLOrder7TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    OLOrder7NumDrinksLabel.Text = numDrinks.ToString();
                } else if (num == 7)
                {
                    OLOrder8IDLabel.Text = o.id.ToString();
                    OLOrder8TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder8NameLabel.Text = o.firstname;
                    OLOrder8NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks++;
                    }
                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks++;
                    }
                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks++;
                    }
                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks++;
                    }
                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks++;
                    }


                    OLOrder8TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    OLOrder8NumDrinksLabel.Text = numDrinks.ToString();
                } else if(num == 8)
                {
                    OLOrder9IDLabel.Text = o.id.ToString();
                    OLOrder9TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder9NameLabel.Text = o.firstname;
                    OLOrder9NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks++;
                    }
                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks++;
                    }
                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks++;
                    }
                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks++;
                    }
                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks++;
                    }


                    OLOrder9TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    OLOrder9NumDrinksLabel.Text = numDrinks.ToString();
                } else if(num == 9)
                {
                    OLOrder10IDLabel.Text = o.id.ToString();
                    OLOrder10TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder10NameLabel.Text = o.firstname;
                    OLOrder10NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks++;
                    }
                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks++;
                    }
                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks++;
                    }
                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks++;
                    }
                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks++;
                    }


                    OLOrder10TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    OLOrder10NumDrinksLabel.Text = numDrinks.ToString();
                }
                num++;
            }
        }
    }
}