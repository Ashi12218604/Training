using System;
class Lon
{
    public static void larger()
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());

        if (a > b && a > c)
            Console.WriteLine($"A {a} is the greatest");
        else if (b > c)
            Console.WriteLine($"B {b} is the greatest");
        else
            Console.WriteLine($"C {c} is the greatest");
    }
}
