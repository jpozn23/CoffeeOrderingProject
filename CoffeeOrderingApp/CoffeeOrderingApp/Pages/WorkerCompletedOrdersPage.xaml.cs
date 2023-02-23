using CoffeeOrderingApp.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkerCompletedOrdersPage : ContentPage
    {
        //readonly String serverURL = "https://10.0.1.218:8080"; // https may give ssl errors
        readonly String serverURL = "http://192.168.1.13:8090";  //  // Change this to your real IP address.  
        //readonly String serverURL = "http://192.168.0.57:8090";  //  // Change this to your real IP address.  

        public WorkerCompletedOrdersPage()
        {
            InitializeComponent();
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();

            // get orders
            List<Order> userOrders = await GetOrders();

            // get only completed order and add from latest to oldest
            List<Order> completedOrders = new List<Order>();
            for(int i = userOrders.Count-1; i >= 0; i--)
            {
                if (userOrders[i].isCompleted == true)
                {
                    completedOrders.Add(userOrders[i]);
                }
            }



            // display orders
            DisplayOrders(completedOrders);
        }

        public async Task<List<Order>> GetOrders()
        {
            HttpClient client;
            client = new HttpClient();
            var uri = new Uri(serverURL + "/api/Order");
            var response = await client.GetAsync(uri);

            List<Order> orders = null;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                orders = JsonConvert.DeserializeObject<List<Order>>(content);
            }

            return orders;
        }

        public void DisplayOrders(List<Order> orders)
        {
            int orderNum = 0;
            foreach(Order o in orders)
            {
                if(orderNum == 0)
                {
                    Order1IDLabel.Text = o.id.ToString();
                    Order1TimeLabel.Text = o.pickupTime.ToString();
                    Order1NameLabel.Text = o.firstname;
                    double total = 0;
                    int numDrinks = 0;
                    if(o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks = numDrinks + 1;
                    }

                    Order1TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    Order1NumDrinksLabel.Text = numDrinks.ToString();

                } else if (orderNum == 1)
                {
                    Order2IDLabel.Text = o.id.ToString();
                    Order2TimeLabel.Text = o.pickupTime.ToString();
                    Order2NameLabel.Text = o.firstname;

                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks = numDrinks + 1;
                    }

                    Order2TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    Order2NumDrinksLabel.Text = numDrinks.ToString();

                } else if (orderNum == 2)
                {
                    Order3IDLabel.Text = o.id.ToString();
                    Order3TimeLabel.Text = o.pickupTime.ToString();
                    Order3NameLabel.Text = o.firstname;

                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks = numDrinks + 1;
                    }

                    Order3TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    Order3NumDrinksLabel.Text = numDrinks.ToString();

                } else if (orderNum == 3)
                {
                    Order4IDLabel.Text = o.id.ToString();
                    Order4TimeLabel.Text = o.pickupTime.ToString();
                    Order4NameLabel.Text = o.firstname;

                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks = numDrinks + 1;
                    }

                    Order4TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    Order4NumDrinksLabel.Text = numDrinks.ToString();

                } else if (orderNum == 4)
                {
                    Order5IDLabel.Text = o.id.ToString();
                    Order5TimeLabel.Text = o.pickupTime.ToString();
                    Order5NameLabel.Text = o.firstname;

                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks = numDrinks + 1;
                    }

                    Order5TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    Order5NumDrinksLabel.Text = numDrinks.ToString();

                } else if (orderNum == 5)
                {
                    Order6IDLabel.Text = o.id.ToString();
                    Order6TimeLabel.Text = o.pickupTime.ToString();
                    Order6NameLabel.Text = o.firstname;

                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks = numDrinks + 1;
                    }

                    Order6TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    Order6NumDrinksLabel.Text = numDrinks.ToString();

                } else if (orderNum == 6)
                {
                    Order7IDLabel.Text = o.id.ToString();
                    Order7TimeLabel.Text = o.pickupTime.ToString();
                    Order7NameLabel.Text = o.firstname;

                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks = numDrinks + 1;
                    }

                    Order7TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    Order7NumDrinksLabel.Text = numDrinks.ToString();

                } else if (orderNum == 7)
                {
                    Order8IDLabel.Text = o.id.ToString();
                    Order8TimeLabel.Text = o.pickupTime.ToString();
                    Order8NameLabel.Text = o.firstname;

                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks = numDrinks + 1;
                    }

                    Order8TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    Order8NumDrinksLabel.Text = numDrinks.ToString();

                } else if (orderNum == 8)
                {
                    Order9IDLabel.Text = o.id.ToString();
                    Order9TimeLabel.Text = o.pickupTime.ToString();
                    Order9NameLabel.Text = o.firstname;

                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks = numDrinks + 1;
                    }

                    Order9TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    Order9NumDrinksLabel.Text = numDrinks.ToString();

                } else if (orderNum == 9)
                {
                    Order10IDLabel.Text = o.id.ToString();
                    Order10TimeLabel.Text = o.pickupTime.ToString();
                    Order10NameLabel.Text = o.firstname;

                    double total = 0;
                    int numDrinks = 0;
                    if (o.drink1 != null)
                    {
                        total = total + o.drink1.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink2 != null)
                    {
                        total = total + o.drink2.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink3 != null)
                    {
                        total = total + o.drink3.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink4 != null)
                    {
                        total = total + o.drink4.cost;
                        numDrinks = numDrinks + 1;
                    }

                    if (o.drink5 != null)
                    {
                        total = total + o.drink5.cost;
                        numDrinks = numDrinks + 1;
                    }

                    Order10TotalLabel.Text = "$" + String.Format("{0:0.00}", total);
                    Order10NumDrinksLabel.Text = numDrinks.ToString();

                } else
                {

                }
                orderNum++;
            }
        }
    }
}