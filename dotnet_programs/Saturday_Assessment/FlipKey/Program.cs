using System;
public class Program
{
    public static void Main()
    {
         FlipKey sc=new FlipKey();
       Console.Write("Enter input string: ");
        string input=Console.ReadLine();
        string result=sc.cleansandinvert(input);
        if (result == "")
            Console.WriteLine("Invalid input");
        else
            Console.WriteLine("New String is: " + result);

    }
}