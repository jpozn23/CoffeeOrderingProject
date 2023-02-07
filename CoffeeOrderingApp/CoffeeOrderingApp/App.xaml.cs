using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeOrderingApp
{
    public partial class App : Application
    {
        public static IPlatformSpecific PlatformSpecific { get; private set; }

        public static void Init(IPlatformSpecific platformSpecificImplementation)
        {
            App.PlatformSpecific = platformSpecificImplementation;
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
