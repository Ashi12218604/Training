using System;
using System.Globalization;

interface IArea
{
    double Area();
}

abstract class Shape : IArea
{
    public abstract double Area();
}

class Circle : Shape
{
    double r;

    public Circle(double r)
    {
        this.r = r;
    }

    public override double Area()
    {
        return Math.PI * r * r;
    }
}

class Rectangle : Shape
{
    double w;
    double h;

    public Rectangle(double w, double h)
    {
        this.w = w;
        this.h = h;
    }

    public override double Area()
    {
        return w * h;
    }
}

class Triangle : Shape
{
    double b;
    double h;

    public Triangle(double b, double h)
    {
        this.b = b;
        this.h = h;
    }

    public override double Area()
    {
        return 0.5 * b * h;
    }
}

public class Solution
{
    public static double TotalArea(string[] shapes)
    {
        double total = 0;

        for (int i = 0; i < shapes.Length; i++)
        {
            string[] p = shapes[i].Split(' ');
            Shape s = null;

            if (p[0] == "C")
                s = new Circle(double.Parse(p[1]));
            else if (p[0] == "R")
                s = new Rectangle(double.Parse(p[1]), double.Parse(p[2]));
            else if (p[0] == "T")
                s = new Triangle(double.Parse(p[1]), double.Parse(p[2]));

            if (s != null)
                total += s.Area();
        }

        return Math.Round(total, 2, MidpointRounding.AwayFromZero);
    }

    public static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] shapes = new string[n];

        for (int i = 0; i < n; i++)
            shapes[i] = Console.ReadLine();

        double result = TotalArea(shapes);
        Console.WriteLine(result.ToString("F2", CultureInfo.InvariantCulture));
    }
}
