using System;
using System.Reflection;

namespace ReflectionDemo
{
    public static class FieldInspector
    {
        public static void ShowFields()
        {
            Type t = typeof(Employee);
            FieldInfo[] fields = t.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (var f in fields)
                Console.WriteLine(f.Name);
        }
    }
}
