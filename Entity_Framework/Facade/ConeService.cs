using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    internal class ConeService
    {
        public string GetCone()
        {
            Console.WriteLine("Preparing Cones");
            return "Waffle Cone ";
        }
    }
}
