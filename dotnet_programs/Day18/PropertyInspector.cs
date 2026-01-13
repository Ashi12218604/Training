using System;
using System.Reflection;

namespace ReflectionDemo
{
    public static class PropertyInspector
    {
        public static void ShowProperties()
        {
            Type t = typeof(Employee);
            PropertyInfo[] props = t.GetProperties();
            foreach (var p in props)
                Console.WriteLine(p.Name);
        }
    }
}
