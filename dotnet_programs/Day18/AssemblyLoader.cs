using System;
using System.Reflection;

namespace ReflectionDemo
{
    public static class AssemblyLoader
    {
        public static void LoadCurrentAssembly()
        {
            Console.WriteLine(Assembly.GetExecutingAssembly().FullName);
        }

        public static void LoadByName(string name)
        {
            try
            {
                Console.WriteLine(Assembly.Load(name).FullName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void LoadFromFile(string file)
        {
            try
            {
                Console.WriteLine(Assembly.LoadFrom(file).FullName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
