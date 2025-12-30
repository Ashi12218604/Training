using System;

class Aoc
{
    public static void Area_of_Circle()
    {
        double r = Convert.ToDouble(Console.ReadLine());
        double area = Math.PI * r * r;
        Console.WriteLine($"Area of circle: {area}");
    }
}