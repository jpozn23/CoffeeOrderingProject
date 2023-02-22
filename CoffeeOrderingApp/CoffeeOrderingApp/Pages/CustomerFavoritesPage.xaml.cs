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
    public partial class CustomerFavoritesPage : ContentPage
    {
        public CustomerFavoritesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Set Vars
            if(Singletons.UserSingleton.Instance.favdrink1 != null)
            {
                FavDrink1TypeLabel.Text = Singletons.UserSingleton.Instance.favdrink1.drinkType;
                FavDrink1SizeLabel.Text = Singletons.UserSingleton.Instance.favdrink1.drinkSize;
                FavDrink1TotalLabel.Text = Singletons.UserSingleton.Instance.favdrink1.cost.ToString();

                if (Singletons.UserSingleton.Instance.favdrink1.addsubs.Length >= 2)
                {
                    String s = Singletons.UserSingleton.Instance.favdrink1.addsubs;
                    s = s.Substring(1);
                    FavDrink1ASLabel.Text = s;
                }

                FavoriteDrink1Button.IsEnabled = true;

            }

            if (Singletons.UserSingleton.Instance.favdrink2 != null)
            {
                FavDrink2TypeLabel.Text = Singletons.UserSingleton.Instance.favdrink2.drinkType;
                FavDrink2SizeLabel.Text = Singletons.UserSingleton.Instance.favdrink2.drinkSize;
                FavDrink2TotalLabel.Text = Singletons.UserSingleton.Instance.favdrink2.cost.ToString();

                if (Singletons.UserSingleton.Instance.favdrink2.addsubs.Length >= 2)
                {
                    String s = Singletons.UserSingleton.Instance.favdrink2.addsubs;
                    s = s.Substring(1);
                    FavDrink2ASLabel.Text = s;
                }

                FavoriteDrink2Button.IsEnabled = true;
            }

            if (Singletons.UserSingleton.Instance.favdrink3 != null)
            {
                FavDrink3TypeLabel.Text = Singletons.UserSingleton.Instance.favdrink3.drinkType;
                FavDrink3SizeLabel.Text = Singletons.UserSingleton.Instance.favdrink3.drinkSize;
                FavDrink3TotalLabel.Text = Singletons.UserSingleton.Instance.favdrink3.cost.ToString();

                if (Singletons.UserSingleton.Instance.favdrink3.addsubs.Length >= 2)
                {
                    String s = Singletons.UserSingleton.Instance.favdrink3.addsubs;
                    s = s.Substring(1);
                    FavDrink3ASLabel.Text = s;
                }

                FavoriteDrink3Button.IsEnabled = true;
            }

            if (Singletons.UserSingleton.Instance.favdrink4 != null)
            {
                FavDrink4TypeLabel.Text = Singletons.UserSingleton.Instance.favdrink4.drinkType;
                FavDrink4SizeLabel.Text = Singletons.UserSingleton.Instance.favdrink4.drinkSize;
                FavDrink4TotalLabel.Text = Singletons.UserSingleton.Instance.favdrink4.cost.ToString();

                if (Singletons.UserSingleton.Instance.favdrink4.addsubs.Length >= 2)
                {
                    String s = Singletons.UserSingleton.Instance.favdrink4.addsubs;
                    s = s.Substring(1);
                    FavDrink4ASLabel.Text = s;
                }

                FavoriteDrink4Button.IsEnabled = true;
            }

            if (Singletons.UserSingleton.Instance.favdrink5 != null)
            {
                FavDrink5TypeLabel.Text = Singletons.UserSingleton.Instance.favdrink5.drinkType;
                FavDrink5SizeLabel.Text = Singletons.UserSingleton.Instance.favdrink5.drinkSize;
                FavDrink5TotalLabel.Text = Singletons.UserSingleton.Instance.favdrink5.cost.ToString();

                if (Singletons.UserSingleton.Instance.favdrink5.addsubs.Length >= 2)
                {
                    String s = Singletons.UserSingleton.Instance.favdrink5.addsubs;
                    s = s.Substring(1);
                    FavDrink5ASLabel.Text = s;
                }

                FavoriteDrink5Button.IsEnabled = true;
            }

        }

        async private void FavoriteDrink1Button_Clicked(object sender, EventArgs e)
        {
            Singletons.FavoriteSingleton.Instance.drink = Singletons.UserSingleton.Instance.favdrink1;
            await Navigation.PushAsync(new CustomerAddItemMenuPage());
        }

        async private void FavoriteDrink2Button_Clicked(object sender, EventArgs e)
        {
            Singletons.FavoriteSingleton.Instance.drink = Singletons.UserSingleton.Instance.favdrink2;
            await Navigation.PushAsync(new CustomerAddItemMenuPage());
        }

        async private void FavoriteDrink3Button_Clicked(object sender, EventArgs e)
        {
            Singletons.FavoriteSingleton.Instance.drink = Singletons.UserSingleton.Instance.favdrink3;
            await Navigation.PushAsync(new CustomerAddItemMenuPage());
        }

        async private void FavoriteDrink4Button_Clicked(object sender, EventArgs e)
        {
            Singletons.FavoriteSingleton.Instance.drink = Singletons.UserSingleton.Instance.favdrink4;
            await Navigation.PushAsync(new CustomerAddItemMenuPage());
        }

        async private void FavoriteDrink5Button_Clicked(object sender, EventArgs e)
        {
            Singletons.FavoriteSingleton.Instance.drink = Singletons.UserSingleton.Instance.favdrink5;
            await Navigation.PushAsync(new CustomerAddItemMenuPage());
        }
    }
}