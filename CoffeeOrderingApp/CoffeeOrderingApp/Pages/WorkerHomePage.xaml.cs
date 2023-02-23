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
    public partial class WorkerHomePage : ContentPage
    {
        public WorkerHomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NameLabel.Text = Singletons.UserSingleton.Instance.firstname;
        }

        async private void CompletedOrdersButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkerCompletedOrdersPage());
        }

        
        async private void CurrentOrdersButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkerCurrentOrdersPage());
        }

        async private void LogOutButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}