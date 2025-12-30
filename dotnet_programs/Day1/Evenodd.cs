using System;
class Evenodd
{
    public static void check()
    {
        Console.WriteLine("Enter value of num");
        int num=Convert.ToInt32(Console.ReadLine());
        if(num%2==0)
        Console.WriteLine("Number is even");
        else
        Console.WriteLine("Number is Odd");
    }
}