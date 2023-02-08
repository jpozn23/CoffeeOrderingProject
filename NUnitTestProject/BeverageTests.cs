using CoffeeOrderingApp;
using NUnit.Framework;
using System;

namespace NUnitTestProject
{
    public class BeverageTests
    {
        private Beverage beverage1 { get; set; } = null;
        private Beverage beverage2 { get; set; } = null;

        private Beverage beverage3 { get; set; } = null;

        private Beverage beverage4 { get; set; } = null;

        [SetUp]
        public void Setup()
        {
            beverage1 = new Americano("Grande");
            beverage1 = new Almond_Milk(beverage1);
            beverage1 = new Soy_Milk(beverage1);

            beverage2 = new Caramel("Venti");
            beverage2 = new Coconut_Milk(beverage2);
            beverage2 = new Espresso_Addon(beverage2);
            beverage2 = new Made_With_Lemonade(beverage2);

            beverage3 = new Hot_Tea("Grande");
            beverage3 = new Flavor_Sauce(beverage3);

            beverage4 = new Pink_Drink("Venti");
        }

        [Test]
        public void GetBeverageSize_EqualTest()
        {
            var size1 = beverage1.GetDrinkSize();
            var size2 = beverage2.GetDrinkSize();
            var size3 = beverage3.GetDrinkSize();
            var size4 = beverage4.GetDrinkSize();

            Assert.AreEqual("Grande", size1);
            Assert.AreEqual("Venti", size2);
            Assert.AreEqual("Grande", size3);
            Assert.AreEqual("Venti", size4);
        }

        [Test]
        public void GetBeverageType_EqualTest()
        {
            var type1 = beverage1.GetDrinkType();
            var type2 = beverage2.GetDrinkType();
            var type3 = beverage3.GetDrinkType();
            var type4 = beverage4.GetDrinkType();

            Assert.AreEqual("Espresso - Americano", type1);
            Assert.AreEqual("Frappuccino - Caramel", type2);
            Assert.AreEqual("Iced Coffee and Tea - Hot Tea", type3);
            Assert.AreEqual("Specialty Beverage - Pink Drink", type4);
        }

        
        [Test]
        public void GetBeverageCost_EqualTest()
        {
            var cost1 = Math.Round(beverage1.Cost(), 2);
            var cost2 = Math.Round(beverage2.Cost(), 2);
            var cost3 = Math.Round(beverage3.Cost(), 2);
            var cost4 = Math.Round(beverage4.Cost(), 2);

            Assert.AreEqual(5.27, cost1);
            Assert.AreEqual(8.76, cost2);
            Assert.AreEqual(4.28, cost3);
            Assert.AreEqual(5.69, cost4);
        }
        

        [Test]
        public void GetBeverageAddsAndSubs_EqualTest()
        {
            var addsubs1 = beverage1.GetAddSubs();
            var addsubs2 = beverage2.GetAddSubs();
            var addsubs3 = beverage3.GetAddSubs();
            var addsubs4 = beverage4.GetAddSubs();

            Assert.AreEqual(", Almond Milk , Soy Milk ", addsubs1);
            Assert.AreEqual(", Coconut Milk , Espresso , Made with Lemonade ", addsubs2);
            Assert.AreEqual(", Flavor Sauce ", addsubs3);
            Assert.AreEqual("", addsubs4);
        }

    }
}