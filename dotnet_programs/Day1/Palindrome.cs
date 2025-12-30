using System;
class Palindrome
{
    public static void palin()
    {
       
        int d=0,r=0;
        int num=Convert.ToInt32(Console.ReadLine());
        int n=num;
        while(num>0)
       {
        d=num%10;
        r=r*10+d;
        num/=10;
       }
       if(n==r)
    Console.WriteLine($"{n} is a Palindrome Number");
    else
    Console.WriteLine($"{n} is not a Palindrome Number");
    }
}