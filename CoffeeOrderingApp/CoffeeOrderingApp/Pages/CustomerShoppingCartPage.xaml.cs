using System;
using System.Collections.Generic;
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
                    Drink1NameLabel.Text = "Type: " + b.GetDrinkType();

                    String s = b.GetAddSubs();
                    s = s.Substring(1);
                    Drink1AddSubsLabel.Text = "Details: " + s;

                    Drink1TotalLabel.Text = b.Cost().ToString();
                } else if (i == 1)
                {
                    Drink2NameLabel.Text = "Type: " + b.GetDrinkType();

                    String s = b.GetAddSubs();
                    s = s.Substring(1);
                    Drink2AddSubsLabel.Text = "Details: " + s;

                    Drink2TotalLabel.Text = b.Cost().ToString();
                } else if (i == 2)
                {
                    Drink3NameLabel.Text = "Type: " + b.GetDrinkType();

                    String s = b.GetAddSubs();
                    s = s.Substring(1);
                    Drink3AddSubsLabel.Text = "Details: " + s;

                    Drink3TotalLabel.Text = b.Cost().ToString();
                } else if (i == 3)
                {
                    Drink4NameLabel.Text = "Type: " + b.GetDrinkType();

                    String s = b.GetAddSubs();
                    s = s.Substring(1);
                    Drink4AddSubsLabel.Text = "Details: " + s;

                    Drink4TotalLabel.Text = b.Cost().ToString();
                } else if (i == 4)
                {
                    Drink5NameLabel.Text = "Type: " + b.GetDrinkType();

                    String s = b.GetAddSubs();
                    s = s.Substring(1);
                    Drink5AddSubsLabel.Text = "Details: " + s;

                    Drink5TotalLabel.Text = b.Cost().ToString();
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
            TotalOrderPriceLabel.Text = total.ToString();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            DisplayDrinks();

            DisplayTotal();
            
        }

        async private void Checkout_Clicked(object sender, EventArgs e)
        {
            // Write order to file



            await DisplayAlert("Successful Order", "Your order has been sent.", "Ok");


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

            await Navigation.PushAsync(new CustomerHomePage());
        }
    }
}