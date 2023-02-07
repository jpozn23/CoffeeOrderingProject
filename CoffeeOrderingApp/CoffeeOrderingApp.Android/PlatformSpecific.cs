using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeOrderingApp.Droid
{
    class PlatformSpecific : IPlatformSpecific
    {
        public String GetPublicStoragePath()
        {
            return Android.App.Application.Context.GetExternalFilesDir(null).AbsoluteFile.ToString();
        }
    }
}