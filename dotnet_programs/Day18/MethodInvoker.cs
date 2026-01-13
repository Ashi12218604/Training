using System;
using System.Reflection;

namespace ReflectionDemo
{
    public static class MethodInvoker
    {
        public static void InvokeMethod()
        {
            Type t = typeof(Employee);
            object? obj = Activator.CreateInstance(t);
            if (obj == null) return;

            MethodInfo? m = t.GetMethod("Add");
            if (m == null) return;

            object? result = m.Invoke(obj, new object[] { 10, 20 });
            Console.WriteLine(result);
        }
    }
}
