using System;
using System.Reflection;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        string dllPath = @"C:\All semesters\Training\dotnet_programs\Saturday_Assessment\DLL FILE\bin\Debug\net10.0\DLL FILE.dll";
        Assembly asm = Assembly.LoadFrom(dllPath);

        Console.WriteLine("Assembly Loaded: " + asm.FullName);

        Console.WriteLine("\n--- Types inside DLL ---");
        foreach (var t in asm.GetTypes())
        {
            Console.WriteLine(t.FullName);
        }
        Console.WriteLine("------------------------");
        Type schoolBluePrintType = asm.GetType("dllJ.SchoolBluePrint");
        if (schoolBluePrintType == null)
        {
            Console.WriteLine("\nSchoolBluePrint class not found in DLL.");
            return;
        }
        MethodInfo[] methods = schoolBluePrintType.GetMethods(
            BindingFlags.Public | BindingFlags.Instance
        );
        Console.WriteLine("\nAll methods in SchoolBluePrint (including inherited):");
        foreach (var method in methods)
        {
            if (method.DeclaringType != typeof(object))
                Console.WriteLine(method.Name);
        }

        int count = methods.Count(m => m.DeclaringType != typeof(object));
        Console.WriteLine($"\nTotal Method Count: {count}");
    }
}