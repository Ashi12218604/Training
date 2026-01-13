using System;
using System.Reflection;

namespace ReflectionDemo
{
    public static class ConstructorInspector
    {
        public static void ShowConstructors()
        {
            Type t = typeof(Employee);
            ConstructorInfo[] ctors = t.GetConstructors();

            foreach (var c in ctors)
                Console.WriteLine(c.ToString());
        }
    }
}
