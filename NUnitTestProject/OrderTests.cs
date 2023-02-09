using CoffeeOrderingApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject
{
    public class OrderTests
    {
        public List<Beverage> beverages = new List<Beverage>();

        [SetUp]
        public void Setup()
        {
            Beverage b1 = new Cafe_Mocha("Grande");
            b1 = new Almond_Milk(b1);
            b1 = new Coconut_Milk(b1);

            Beverage b2 = new Chocolate_Chip("Venti");
            b2 = new Flavor_Sauce(b2);

            Beverage b3 = new Hot_Tea("Grande");
            b3 = new Soy_Milk(b3);
            b3 = new Espresso_Addon(b3);
            b3 = new Flavor_Shot(b3);

            beverages.Add(b1);
            beverages.Add(b2);
            beverages.Add(b3);
        }

        [Test]
        public void VerifyOrderTotal_Test()
        {
            double total = 0;
            foreach (Beverage b in beverages)
            {
                total = total + b.Cost();
            }
            total = Math.Round((total * 1.06), 2);

            Assert.AreEqual(21.21, total);
        }

    }
}