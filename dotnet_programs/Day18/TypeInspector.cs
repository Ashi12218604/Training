using System;

namespace ReflectionDemo
{
    public static class TypeInspector
    {
        public static void DisplayTypeInfo()
        {
            Type t1 = typeof(Employee);
            Console.WriteLine(t1.FullName);

            Employee e = new Employee();
            Type t2 = e.GetType();
            Console.WriteLine(t2.FullName);

            Type? t3 = Type.GetType("ReflectionDemo.Employee");
            if (t3 != null)
                Console.WriteLine(t3.FullName);
        }
    }
}
