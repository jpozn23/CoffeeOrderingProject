using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NUnitTestProject
{
    public class FavoriteTests
    {
        Entry drinkCategory = new Entry();
        Entry drinkType = new Entry();
        Entry drinkSize = new Entry();
        Entry addsub1 = new Entry();
        Entry addsub2 = new Entry();
        Entry addsub3 = new Entry();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckEmptyFields()
        {

            drinkCategory.Text = "";
            drinkType.Text = "";
            drinkSize.Text = "";
            addsub1.Text = "";
            addsub2.Text = "";
            addsub3.Text = "";

            int result = 0;
            if (String.IsNullOrEmpty(drinkCategory.Text) || String.IsNullOrEmpty(drinkType.Text) || String.IsNullOrEmpty(drinkSize.Text)
               || String.IsNullOrEmpty(addsub1.Text) || String.IsNullOrEmpty(addsub2.Text) || String.IsNullOrEmpty(addsub3.Text))
            {
                result = 0;
            }
            else
            {
                result = 1;
            }

            Assert.AreEqual(0, result);


        }

        [Test]
        public void CheckValidFields()
        {

            drinkCategory.Text = "Frappuccino";
            drinkType.Text = "Caramel";
            drinkSize.Text = "Grande";
            addsub1.Text = "Soy Milk";
            addsub2.Text = "None";
            addsub3.Text = "None";


            int result = 0;
            if (String.IsNullOrEmpty(drinkCategory.Text) || String.IsNullOrEmpty(drinkType.Text) || String.IsNullOrEmpty(drinkSize.Text)
               || String.IsNullOrEmpty(addsub1.Text) || String.IsNullOrEmpty(addsub2.Text) || String.IsNullOrEmpty(addsub3.Text))
            {
                result = 0;
            }
            else
            {
                result = 1;
            }

            Assert.AreEqual(1, result);
        }

    }
}