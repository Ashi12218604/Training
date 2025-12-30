using System;

class FTC

{
    public static void FeetToCenti()
    {
        double feet = Convert.ToDouble(Console.ReadLine());
        double centi = feet * 30.48;
        Console.WriteLine("Centimeters:" + centi);
        }
}