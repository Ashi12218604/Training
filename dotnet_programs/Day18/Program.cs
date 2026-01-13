// using System;

// namespace ReflectionDemo
// {
//     class Program
//     {
//         static void Main()
//         {
            
//             AssemblyLoader.LoadCurrentAssembly();
//             AssemblyLoader.LoadByName("MyLibrary");
//             AssemblyLoader.LoadFromFile("MyPlugin.dll");

//             TypeInspector.DisplayTypeInfo();
//             MethodInspector.ShowMethods();
//             PropertyInspector.ShowProperties();
//             FieldInspector.ShowFields();
//             ConstructorInspector.ShowConstructors();

//             MethodInvoker.InvokeMethod();
//             ObjectCreator.CreateUsingReflection();

//             AttributeReader.ReadClassAttributes();
//             AttributeReader.ReadPropertyAttributes();

//             CarInspection.RunInspection();
//         }
//     }
// }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
class Program
{
    static void Main()
    {
        Console.WriteLine("=====ASSEMBLY====-");
        Assembly assembly = Assembly.GetExecutingAssembly(); //Assembly Class
        Console.WriteLine("Assembly Name: " + assembly.GetName().Name);
        Console.WriteLine("\n====Types====");
        foreach(Type t in assembly.GetTypes())
        {
            Console.WriteLine(t.Name);
        }
        //Assembly.Load("MyLibrary")    ;
        //Assembly.LoadFrom("MyPlugin.dll");
        Type type = typeof(Employee); //Type Class
        Console.WriteLine("\n====== TYPE INFO ======");
        Console.WriteLine("Class Name: " + type.Name);
        Console.WriteLine("Namespace: " + type.Namespace);
        Console.WriteLine("IsClass: " + type.IsClass);
        Console.WriteLine("IsPublic: " + type.IsPublic);
        Console.WriteLine("\n====== FIELDS ======");
        foreach(FieldInfo field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
        {
            Console.WriteLine($"{field.Name} - {field.FieldType}");
        }
        Console.WriteLine("\n=====Properties=====");
        foreach (PropertyInfo prop in type.GetProperties())
        {
            Console.WriteLine($"{prop.Name} - {prop.PropertyType}");
        }
        // for dynamic object creation
        Console.WriteLine("\n=====CONSTRUCTORS=====");  //default parameter of employee class
        foreach(ConstructorInfo ctor in type.GetConstructors())  //will give all public constructors
        {
            Console.WriteLine(ctor);
            foreach(ParameterInfo p in ctor.GetParameters()) //Parameterized  , //.ctor is shown because we use reflection that shows internal name
            {
                Console.WriteLine($" Param: {p.Name} - {p.ParameterType}");
            }
        }
        //Type type = employeeObject.GetType();
        //Type type = Type.GetType("MyApp.Models.Employee");
        Console.WriteLine("\n====Methods====");
        foreach(MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
        {
            Console.WriteLine(method.Name);
        }
        //MethodInfo
        //method.Invoke(obj, null);
        Console.WriteLine("\n====== EVENTS ======");
        foreach(EventInfo evt in type.GetEvents())
        {
            Console.WriteLine(evt.Name);
        }
        // Console.WriteLine("\n====== ATTRIBUTES ======");
        // foreach(Attribute attr in type.GetCustomAttribute())
        // {
        //     if(attr is InfoAttribute info)
        //     {
        //         Console.WriteLine(info.Description);
        //     }
        // }
        Console.WriteLine("\n===== ACTIVATOR AND METHOD =====");
        object obj = Activator.CreateInstance(type, 101, "Ashi");
        MethodInfo workMethod = type.GetMethod("Work");
        workMethod.Invoke(obj, null);
        Console.WriteLine("\n===== PRIVATE METHOD =====");
        MethodInfo privateMethod = type.GetMethod("Secret", BindingFlags.NonPublic | BindingFlags.Instance);
        privateMethod.Invoke(obj, null);
        Console.WriteLine("\n===== MEMBERINFO (ALL MEMBERS) =====");
        foreach(MemberInfo member in type.GetMembers())
        {
            Console.WriteLine($"{member.MemberType} - {member.Name}");
        }
    }
}