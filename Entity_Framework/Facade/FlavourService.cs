using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    internal class FlavourService
    {
        public string GetFlavour()
        {
            Console.WriteLine("Checking the available falvours....");
            return "Vanilla Ice Cream";
        }
    }
}
