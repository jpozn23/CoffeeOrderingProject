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


        private void CompleteOrderButton_Clicked(object sender, EventArgs e)
        {

        }

        private void CancelOrderButton_Clicked(object sender, EventArgs e)
        {

        }

        async private void ViewOrdersInQueueButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkerOrderPage());
        }

        async private void LogOutButtonButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}