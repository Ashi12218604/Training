using System;
using System.Reflection;

namespace ReflectionDemo
{
    public static class AttributeReader
    {
        public static void ReadClassAttributes()
        {
            Type t = typeof(Car);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (var a in attrs)
                Console.WriteLine(a);
        }

        public static void ReadPropertyAttributes()
        {
            Type t = typeof(Car);
            foreach (var p in t.GetProperties())
            {
                foreach (var a in p.GetCustomAttributes(false))
                    Console.WriteLine($"{p.Name}: {a}");
            }
        }
    }
}
