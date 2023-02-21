using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeOrderingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        //readonly String serverURL = "https://10.0.1.218:8080"; // https may give ssl errors
        readonly String serverURL = "http://192.168.1.13:8090";  //  // Change this to your real IP address.  
        public MenuPage()
        {
            InitializeComponent();
        }

        async private void BackToHomeButton_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new MainPage());;
            // hijackaing the back button
            var items = await GetMenu();
            if (items.Count > 0)
            {
                var testItem = items.FirstOrDefault();
                String msg = "name: " + testItem.name + " price: " + testItem.price;
                await DisplayAlert("Alert", msg, "OK");
            }
        }

        public async Task<List<CoffeeOrderingApp.Classes.MenuItem>> GetMenu()
        {
            HttpClient client;
            client = new HttpClient();
            var uri = new Uri(serverURL + "/api/Menu");
            var response = await client.GetAsync(uri);
            List<CoffeeOrderingApp.Classes.MenuItem> menuItems = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                menuItems = JsonConvert.DeserializeObject<List<CoffeeOrderingApp.Classes.MenuItem>>(content);
            }
            return menuItems;
        }
    }
}