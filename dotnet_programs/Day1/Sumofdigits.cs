using System;
class Sumofdigits
{
    public static void sum()
    {
       
        int d=0,s=0;
        int num=Convert.ToInt32(Console.ReadLine());
        while(num>0)
       {
        d=num%10;
        s+=d;
        num/=10;
       }
    Console.WriteLine($"Sum of digits is {s}");
    }
}