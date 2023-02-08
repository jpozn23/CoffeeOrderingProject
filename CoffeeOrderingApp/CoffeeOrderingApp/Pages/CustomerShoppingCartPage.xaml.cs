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

        private void Checkout_Clicked(object sender, EventArgs e)
        {

        }
    }
}