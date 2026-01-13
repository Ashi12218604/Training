using System;
using System.Reflection;

namespace ReflectionDemo
{
    public static class CarInspection
    {
        public static void RunInspection()
        {
            Type t = typeof(Car);

            Console.WriteLine(t.FullName);

            object car = Activator.CreateInstance(t);
            PropertyInfo model = t.GetProperty("Model");
            PropertyInfo year = t.GetProperty("Year");

            model.SetValue(car, "Honda City");
            year.SetValue(car, 2021);

            Console.WriteLine(model.GetValue(car));
            Console.WriteLine(year.GetValue(car));

            MethodInfo run = t.GetMethod("IsRunning");
            object result = run.Invoke(car, null);
            Console.WriteLine(result);
        }
    }
}
