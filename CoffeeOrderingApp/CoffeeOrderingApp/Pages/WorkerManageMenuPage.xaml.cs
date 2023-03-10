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
    public partial class WorkerManageMenuPage : ContentPage
    {
        // Change this to your real IP address.  run ipconfig /all in a command prompt
        readonly String serverURL = "http://192.168.1.12:8090";


        public string category = null;
        public WorkerManageMenuPage()
        {
            InitializeComponent();
        }

        public async Task SaveMenuItem(DrinkItem newitem)
        {
            HttpClient client;
            client = new HttpClient();
            var uri = new Uri(serverURL + "/api/Menu");

            String jsonString = JsonConvert.SerializeObject(newitem);
            StringContent strContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, strContent);

            if (response.IsSuccessStatusCode)
            {
                
            }

        }

        

        private void AddItemToMenuButton_Clicked(object sender, EventArgs e)
        {
           // do nothing
        }

        private void UpdateItemFromMenuButton_Clicked(object sender, EventArgs e)
        {

        }

        private void AddItemCategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(AddItemCategoryPicker.SelectedItem.ToString()))
            {
                category = AddItemCategoryPicker.SelectedItem.ToString();
            }
        }
    }
}