using System;
using System.Text;

public class Memorystringbuilders
{
        public static void Run()
    {
         StringBuilder sb=new StringBuilder();

        for (int i=0;i<10000;i++)
        {
            sb.Append(i);
        }

        string result = sb.ToString();
        Console.WriteLine($"Total Memory Before GC: {GC.GetTotalMemory(false)} bytes");
        // Checking Equals behavior
        StringBuilder sb1=new StringBuilder("Hello");
        StringBuilder sb2=new StringBuilder("Hello");
        Console.WriteLine(sb1.Equals(sb2)); //true
        Console.WriteLine(sb1==sb2); // false
        Console.WriteLine(object.ReferenceEquals(sb1, sb2)); //false
        StringBuilder sb3=sb2;
        Console.WriteLine(sb3.Equals(sb2)); // true
        Console.WriteLine(object.ReferenceEquals(sb3, sb2)); //true
         String str1="Hello";
         String str2="Hello";
         Console.WriteLine(str1==str2); //true
        Console.WriteLine(str1.Equals(str2)); //true


    }
}
