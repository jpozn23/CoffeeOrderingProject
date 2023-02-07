using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeOrderingApp
{
    public interface IPlatformSpecific
    {
        String GetPublicStoragePath();
    }
}
