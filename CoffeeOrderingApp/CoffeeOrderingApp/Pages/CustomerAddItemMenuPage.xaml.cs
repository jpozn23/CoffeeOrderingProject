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
    public partial class CustomerAddItemMenuPage : ContentPage
    {
        //readonly String serverURL = "https://10.0.1.218:8080"; // https may give ssl errors
        readonly String serverURL = "http://192.168.1.13:8090";  //  // Change this to your real IP address.  

        public CustomerAddItemMenuPage()
        {
            InitializeComponent();
        }

        private void DrinkCategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When the Drink Category Selected Changes, Drink Type Drop Menu has to change

            if(!String.IsNullOrEmpty(DrinkCategoryPicker.SelectedItem.ToString()))
            {
                if(DrinkCategoryPicker.SelectedItem.ToString() == "Espresso")
                {
                    var espressoList = new List<string>();
                    espressoList.Add("Americano");
                    espressoList.Add("Cafe Latte");
                    espressoList.Add("Cafe Mocha");
                    espressoList.Add("White Chocolate Mocha");
                    espressoList.Add("Caramel Macchiato");
                    espressoList.Add("Chai Latte");
                    espressoList.Add("Matcha Latte");
                    espressoList.Add("Freshly Brewed Coffee");

                    DrinkTypePicker.ItemsSource = espressoList;

                } else if (DrinkCategoryPicker.SelectedItem.ToString() == "Iced Coffee and Tea")
                {
                    var icedCoffeeTea = new List<string>();
                    icedCoffeeTea.Add("Iced Coffee");
                    icedCoffeeTea.Add("Teavana Shaken Iced Tea");
                    icedCoffeeTea.Add("Hot Tea");

                    DrinkTypePicker.ItemsSource = icedCoffeeTea;

                } else if (DrinkCategoryPicker.SelectedItem.ToString() == "Frappuccinos")
                {
                    var frappuccions = new List<string>();
                    frappuccions.Add("Caramel Frappuccino");
                    frappuccions.Add("Chocolate Chip Frappuccino");
                    frappuccions.Add("Mocha Frappuccino");
                    frappuccions.Add("Matcha Green Tea Frappuccino");
                    frappuccions.Add("Strawberries and Cream Frappuccino");
                    frappuccions.Add("Vanilla Frappuccino");
                    frappuccions.Add("Java Chip Frappuccino");
                    frappuccions.Add("Coffee Frappuccino");

                    DrinkTypePicker.ItemsSource = frappuccions;

                } else if (DrinkCategoryPicker.SelectedItem.ToString() == "Specialty Beverages")
                {
                    var specialtyBeverages = new List<string>();
                    specialtyBeverages.Add("Refreshers");
                    specialtyBeverages.Add("Pink Drink");
                    specialtyBeverages.Add("Hot Cocoa");
                    specialtyBeverages.Add("Medicine Ball");

                    DrinkTypePicker.ItemsSource = specialtyBeverages;

                } else
                {
                    var specialtyBeverages = new List<string>();
                    specialtyBeverages.Add("Refreshers");
                    specialtyBeverages.Add("Pink Drink");
                    specialtyBeverages.Add("Hot Cocoa");
                    specialtyBeverages.Add("Medicine Ball");
                    
                    DrinkTypePicker.ItemsSource = specialtyBeverages;
                }
            }
        }

        private bool ValidateInput()
        {
            // validate all fields are filled out
            if(DrinkCategoryPicker.SelectedIndex == -1 || DrinkTypePicker.SelectedIndex == -1 ||
                DrinkSizePicker.SelectedIndex == -1 || DrinkAddOnsSubsPicker1.SelectedIndex == -1 ||
                DrinkAddOnsSubsPicker2.SelectedIndex == -1 || DrinkAddOnsSubsPicker3.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        private Beverage CreateDrink(string category, string type, string size, string addsub1, string addsub2, string addsub3)
        {
            Beverage beverage = new Americano(size);

            // Drink Type
            if(type.Equals("Americano"))
            {
                beverage = new Americano(size);
            } else if (type.Equals("Cafe Latte")) 
            {
                beverage = new Cafe_Latte(size);
            } else if (type.Equals("Cafe Mocha"))
            {
                beverage = new Cafe_Mocha(size);
            } else if (type.Equals("Caramel Macchiato"))
            {
                beverage = new Caramel_Macchiato(size);
            } else if (type.Equals("Chai Latte"))
            {
                beverage = new Chai_Latte(size);
            } else if (type.Equals("Freshly Brewed Coffee"))
            {
                beverage = new Freshly_Brewed_Coffee(size);
            } else if (type.Equals("Matcha Latte"))
            {
                beverage = new Matcha_Latte(size);
            } else if (type.Equals("White Chocolate Mocha"))
            {
                beverage = new White_Chocolate_Mocha(size);
            } else if (type.Equals("Caramel Frappuccino"))
            {
                beverage = new Caramel_Macchiato(size);
            } else if (type.Equals("Chocolate Chip Frappuccino"))
            {
                beverage = new Chocolate_Chip(size);
            } else if (type.Equals("Mocha Frappuccino"))
            {
                beverage = new Mocha(size);
            } else if (type.Equals("Matcha Green Tea Frappuccino"))
            {
                beverage = new Matcha_Green_Tea(size);
            } else if (type.Equals("Strawberries and Cream Frappuccino"))
            {
                beverage = new Strawberries_And_Cream(size);
            } else if (type.Equals("Vanilla Frappuccino"))
            {
                beverage = new Vanilla(size);
            } else if (type.Equals("Coffee Frappuccino"))
            {
                beverage = new Coffee(size);
            } else if (type.Equals("Java Chip Frappuccino"))
            {
                beverage = new Java_Chip(size);
            } else if (type.Equals("Refreshers"))
            {
                beverage = new Strawberry_Acai_Refresher(size);
            } else if (type.Equals("Pink Drink"))
            {
                beverage = new Pink_Drink(size);
            } else if (type.Equals("Hot Cocoa"))
            {
                beverage = new Hot_Cocoa(size);
            } else if (type.Equals("Medicine Ball"))
            {
                beverage = new Medicine_Ball(size);
            } else if (type.Equals("Iced Coffee"))
            {
                beverage = new Iced_Coffee(size);
            } else if (type.Equals("Teavana Shaken Iced Tea"))
            {
                beverage = new Teavana_Shaken_Iced_Tea(size);
            } else if (type.Equals("Hot Tea"))
            {
                beverage = new Hot_Tea(size);
            } else
            {

            }

            // Drink Add-Ons/Subs #1
            if (addsub1.Equals("Espresso"))
            {
                beverage = new Espresso_Addon(beverage); 
            } else if (addsub1.Equals("Almond Milk"))
            {
                beverage = new Almond_Milk(beverage);
            } else if (addsub1.Equals("Soy Milk"))
            {
                beverage = new Soy_Milk(beverage);
            } else if (addsub1.Equals("Coconut Milk"))
            {
                beverage = new Coconut_Milk(beverage);
            } else if (addsub1.Equals("Flavor Shot or Sauce"))
            {
                beverage = new Flavor_Shot(beverage);
            } else if (addsub1.Equals("Made with Lemonade"))
            {
                beverage = new Made_With_Lemonade(beverage);
            } else
            {

            }

            // Drink Add-Ons/Subs #2
            if (addsub2.Equals("Espresso"))
            {
                beverage = new Espresso_Addon(beverage);
            }
            else if (addsub2.Equals("Almond Milk"))
            {
                beverage = new Almond_Milk(beverage);
            }
            else if (addsub2.Equals("Soy Milk"))
            {
                beverage = new Soy_Milk(beverage);
            }
            else if (addsub2.Equals("Coconut Milk"))
            {
                beverage = new Coconut_Milk(beverage);
            }
            else if (addsub2.Equals("Flavor Shot or Sauce"))
            {
                beverage = new Flavor_Shot(beverage);
            }
            else if (addsub2.Equals("Made with Lemonade"))
            {
                beverage = new Made_With_Lemonade(beverage);
            }
            else
            {

            }

            // Drink Add-Ons/Subs #3
            if (addsub3.Equals("Espresso"))
            {
                beverage = new Espresso_Addon(beverage);
            }
            else if (addsub3.Equals("Almond Milk"))
            {
                beverage = new Almond_Milk(beverage);
            }
            else if (addsub3.Equals("Soy Milk"))
            {
                beverage = new Soy_Milk(beverage);
            }
            else if (addsub3.Equals("Coconut Milk"))
            {
                beverage = new Coconut_Milk(beverage);
            }
            else if (addsub3.Equals("Flavor Shot or Sauce"))
            {
                beverage = new Flavor_Shot(beverage);
            }
            else if (addsub3.Equals("Made with Lemonade"))
            {
                beverage = new Made_With_Lemonade(beverage);
            }
            else
            {

            }

            return beverage;

        }

        async private void AddItemButton_Clicked(object sender, EventArgs e)
        {
            // Validate Drink Fields
            bool validate = ValidateInput();
            if(!validate)
            {
                await DisplayAlert("Error", "Invalid Drink. All fields must be filled out.", "Ok");
                return;
            }

            // Get Drink Values
            string drinkCategory = DrinkCategoryPicker.SelectedItem.ToString();
            string drinkType = DrinkTypePicker.SelectedItem.ToString();
            string drinkSize = DrinkSizePicker.SelectedItem.ToString();
            string drinkAddSub1 = DrinkAddOnsSubsPicker1.SelectedItem.ToString();
            string drinkAddSub2 = DrinkAddOnsSubsPicker2.SelectedItem.ToString();
            string drinkAddSub3 = DrinkAddOnsSubsPicker3.SelectedItem.ToString();

            // Create Drink
            Beverage b = CreateDrink(drinkCategory, drinkType, drinkSize, drinkAddSub1, drinkAddSub2, drinkAddSub3);
            
            // Add to Singleton
            Singletons.OrderSingleton.Instance.beverages.Add(b);

            await Navigation.PushAsync(new CustomerHomePage());
        }

        async private void AddItemFavorites_Clicked(object sender, EventArgs e)
        {
            // Validate Drink Fields
            bool validate = ValidateInput();
            if (!validate)
            {
                await DisplayAlert("Error", "All fields must be filled out.", "Ok");
                return;
            }

            // Get Drink Values
            string drinkCategory = DrinkCategoryPicker.SelectedItem.ToString();
            string drinkType = DrinkTypePicker.SelectedItem.ToString();
            string drinkSize = DrinkSizePicker.SelectedItem.ToString();
            string drinkAddSub1 = DrinkAddOnsSubsPicker1.SelectedItem.ToString();
            string drinkAddSub2 = DrinkAddOnsSubsPicker2.SelectedItem.ToString();
            string drinkAddSub3 = DrinkAddOnsSubsPicker3.SelectedItem.ToString();

            // Create Drink
            Beverage b = CreateDrink(drinkCategory, drinkType, drinkSize, drinkAddSub1, drinkAddSub2, drinkAddSub3);

            Drink d = new Drink();
            d.drinkType = b.GetDrinkType();
            d.drinkSize = b.GetDrinkSize();
            d.addsubs = b.GetAddSubs();
            d.cost = b.Cost();

            // Add to favorites
            if (Singletons.UserSingleton.Instance.favdrink1 == null)
            {
                Singletons.UserSingleton.Instance.favdrink1 = d;
            } else if (Singletons.UserSingleton.Instance.favdrink2 == null)
            {
                Singletons.UserSingleton.Instance.favdrink2 = d;
            } else if (Singletons.UserSingleton.Instance.favdrink3 == null)
            {
                Singletons.UserSingleton.Instance.favdrink3 = d;
            } else if (Singletons.UserSingleton.Instance.favdrink4 == null)
            {
                Singletons.UserSingleton.Instance.favdrink4 = d;
            } else
            {
                Singletons.UserSingleton.Instance.favdrink5 = d;
            }

            // Update User
            User user = new User();
            user.firstname = Singletons.UserSingleton.Instance.firstname;
            user.lastname = Singletons.UserSingleton.Instance.lastname;
            user.username = Singletons.UserSingleton.Instance.username;
            user.password = Singletons.UserSingleton.Instance.password;
            user.customerOrWorker = Singletons.UserSingleton.Instance.customerOrWorker;
            user.favorites = Singletons.UserSingleton.Instance.favorites;
            user.favdrink1 = Singletons.UserSingleton.Instance.favdrink1;
            user.favdrink2 = Singletons.UserSingleton.Instance.favdrink2;
            user.favdrink3 = Singletons.UserSingleton.Instance.favdrink3;
            user.favdrink4 = Singletons.UserSingleton.Instance.favdrink4;
            user.favdrink5 = Singletons.UserSingleton.Instance.favdrink5;

            await UpdateAccount(user);

            await DisplayAlert("Success", "Order has been added to favorites", "Ok");

        }

        public async Task UpdateAccount(User newuser)
        {
            HttpClient client;
            client = new HttpClient();

            var uri = new Uri(serverURL + "/api/Account/" + Singletons.UserSingleton.Instance.username);

            String jsonString = JsonConvert.SerializeObject(newuser);
            StringContent strContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(uri, strContent);

            if (response.IsSuccessStatusCode)
            {
               
            }

        }

        async private void SelectDrinkFavorites_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerFavoritesPage());
        }
    }
}