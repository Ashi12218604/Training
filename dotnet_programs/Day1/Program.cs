using System;
using System.Runtime.InteropServices.Marshalling;
//namespace is a container that is used to organize classes, interfaces , structs, enums, and delegates
//dotnet new console -n FileName
//dotnet --list-sdks
//dotnet restore = download dependencies
//dotnet build = compile the code
class Program
   {
        static void Main()
    {
        Console.WriteLine("Enter value of r");
        Aoc.Area_of_Circle();

        Console.WriteLine("Enter value of cm");
        FTC.FeetToCenti();

        Age.eligible();

        Evenodd.check();
        
        Console.WriteLine("Enter value of age");
        Console.WriteLine("Enter whether you have license or not (t/f) ");
        License.Haslicense();

        Console.WriteLine("Enter value of a");
        Console.WriteLine("Enter value of b");
        Console.WriteLine("Enter value of c");
        Lon.larger();

        Console.WriteLine("Enter value of number");
        Sumofdigits.sum();

        Reverse.rev();
        
        Palindrome.palin();
    }
   }