using System;

namespace ReflectionDemo
{
    public static class ObjectCreator
    {
        public static void CreateUsingReflection()
        {
            Type t = typeof(Employee);

            object? obj = Activator.CreateInstance(t, new object[] { 101 });
            if (obj == null) return;

            Console.WriteLine(obj.GetType().Name);
        }
    }
}
