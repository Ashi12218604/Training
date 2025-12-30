using System;
using System.Reflection;
class License
{
    public static void Haslicense()
    {
        int age=Convert.ToInt32(Console.ReadLine());
        bool lic=Convert.ToBoolean(Console.ReadLine());
        if(age>=18)
        {
            if(lic)
            {
                Console.WriteLine("You are allowed to drive");
            }
            else
            Console.WriteLine("You require driving license");
        }
    }
   }