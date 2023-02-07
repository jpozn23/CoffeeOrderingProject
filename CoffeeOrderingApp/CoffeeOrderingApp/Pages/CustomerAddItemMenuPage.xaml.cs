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
    public partial class CustomerAddItemMenuPage : ContentPage
    {
        public CustomerAddItemMenuPage()
        {
            InitializeComponent();
        }

        private void DrinkCategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            if(DrinkCategoryPicker.SelectedIndex == -1 || DrinkTypePicker.SelectedIndex == -1 ||
                DrinkSizePicker.SelectedIndex == -1 || DrinkAddOnsSubsPicker1.SelectedIndex == -1 ||
                DrinkAddOnsSubsPicker2.SelectedIndex == -1 || DrinkAddOnsSubsPicker3.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        private void CreateDrink(string category, string type, string size, string addsub1, string addsub2, string addsub3)
        {
            Beverage beverage = new Americano("Grande");
            beverage = new Almond_Milk(beverage);
            beverage = new Coconut_Milk(beverage);
            //beverage = new Almond_Milk(beverage);

            Console.WriteLine(beverage.Cost());
            Console.WriteLine(beverage.GetDrinkType());
            Console.WriteLine(beverage.GetSize());



            Console.WriteLine("-------");
            Console.WriteLine(category);
            Console.WriteLine(type);
            Console.WriteLine(size);
            Console.WriteLine(addsub1);
            Console.WriteLine(addsub2);
            Console.WriteLine(addsub3);

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
            CreateDrink(drinkCategory, drinkType, drinkSize, drinkAddSub1, drinkAddSub2, drinkAddSub3);

            await Navigation.PushAsync(new CustomerHomePage());
        }

    }
}