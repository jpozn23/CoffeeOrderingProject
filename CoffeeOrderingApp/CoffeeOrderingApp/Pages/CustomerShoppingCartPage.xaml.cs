﻿using System;
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

        private void Checkout_Clicked(object sender, EventArgs e)
        {

        }
    }
}