using CoffeeOrderingApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeOrderingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerHomePage : ContentPage
    {
        public CustomerHomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NameLabel.Text = Singletons.UserSingleton.Instance.firstname;
        }

        async private void AddItemButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerAddItemMenuPage());
        }

        async private void OrderHistoryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerOrderHistoryPage());
        }

        async private void ShoppingCartButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerShoppingCartPage());
        }

        async private void LogOutButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}