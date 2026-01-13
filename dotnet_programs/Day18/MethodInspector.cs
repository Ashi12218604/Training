using System;
using System.Reflection;

namespace ReflectionDemo
{
    public static class MethodInspector
    {
        public static void ShowMethods()
        {
            Type t = typeof(Employee);
            MethodInfo[] methods = t.GetMethods();
            foreach (var m in methods)
                Console.WriteLine(m.Name);
        }
    }
}
