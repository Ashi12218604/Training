using System;
class Reverse
{
    public static void rev()
    {
       
        int d=0,r=0;
        int num=Convert.ToInt32(Console.ReadLine());
        while(num>0)
       {
        d=num%10;
        r=r*10+d;
        num/=10;
       }
    Console.WriteLine($"Reverse of digits is {r}");
    }
}