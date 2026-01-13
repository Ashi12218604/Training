using System;

namespace ReflectionDemo
{
    class Program
    {
        static void Main()
        {
            AssemblyLoader.LoadCurrentAssembly();
            AssemblyLoader.LoadByName("MyLibrary");
            AssemblyLoader.LoadFromFile("MyPlugin.dll");

            TypeInspector.DisplayTypeInfo();
            MethodInspector.ShowMethods();
            PropertyInspector.ShowProperties();
            FieldInspector.ShowFields();
            ConstructorInspector.ShowConstructors();

            MethodInvoker.InvokeMethod();
            ObjectCreator.CreateUsingReflection();

            AttributeReader.ReadClassAttributes();
            AttributeReader.ReadPropertyAttributes();

            CarInspection.RunInspection();
        }
    }
}
