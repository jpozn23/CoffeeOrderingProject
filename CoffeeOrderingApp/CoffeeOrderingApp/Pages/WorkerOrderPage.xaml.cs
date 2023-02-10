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
    public partial class WorkerOrderPage : ContentPage
    {
        public List<Order> orders = new List<Order>();

        public WorkerOrderPage()
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
                    OLOrder1TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder1NameLabel.Text = o.firstname;
                    OLOrder1NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    foreach(Drink d in o.beverages)
                    {
                        total = total + d.cost;
                    }
                    OLOrder1TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                } else if(num == 1)
                {
                    OLOrder2TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder2NameLabel.Text = o.firstname;
                    OLOrder2NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    foreach (Drink d in o.beverages)
                    {
                        total = total + d.cost;
                    }
                    OLOrder2TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                } else if(num == 2)
                {
                    OLOrder3TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder3NameLabel.Text = o.firstname;
                    OLOrder3NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    foreach (Drink d in o.beverages)
                    {
                        total = total + d.cost;
                    }
                    OLOrder3TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                } else if (num == 3)
                {
                    OLOrder4TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder4NameLabel.Text = o.firstname;
                    OLOrder4NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    foreach (Drink d in o.beverages)
                    {
                        total = total + d.cost;
                    }
                    OLOrder4TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                } else if (num == 4)
                {
                    OLOrder5TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder5NameLabel.Text = o.firstname;
                    OLOrder5NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    foreach (Drink d in o.beverages)
                    {
                        total = total + d.cost;
                    }
                    OLOrder5TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                } else if (num == 5)
                {
                    OLOrder6TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder6NameLabel.Text = o.firstname;
                    OLOrder6NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    foreach (Drink d in o.beverages)
                    {
                        total = total + d.cost;
                    }
                    OLOrder6TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                } else if (num == 6)
                {
                    OLOrder7TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder7NameLabel.Text = o.firstname;
                    OLOrder7NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    foreach (Drink d in o.beverages)
                    {
                        total = total + d.cost;
                    }
                    OLOrder7TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                } else if (num == 7)
                {
                    OLOrder8TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder8NameLabel.Text = o.firstname;
                    OLOrder8NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    foreach (Drink d in o.beverages)
                    {
                        total = total + d.cost;
                    }
                    OLOrder8TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                } else if(num == 8)
                {
                    OLOrder9TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder9NameLabel.Text = o.firstname;
                    OLOrder9NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    foreach (Drink d in o.beverages)
                    {
                        total = total + d.cost;
                    }
                    OLOrder9TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                } else if(num == 9)
                {
                    OLOrder10TimeLabel.Text = o.pickupTime.ToString();
                    OLOrder10NameLabel.Text = o.firstname;
                    OLOrder10NumDrinksLabel.Text = o.beverages.Count.ToString();
                    double total = 0;
                    foreach (Drink d in o.beverages)
                    {
                        total = total + d.cost;
                    }
                    OLOrder10TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                }
                num++;
            }
        }
    }
}