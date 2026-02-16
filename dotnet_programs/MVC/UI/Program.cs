using System;
using BAL;
class Program
{
    static void Main()
    {
        CalculatorBL bl = new CalculatorBL();
        Console.WriteLine(bl.BLAdd(5, 6));
    }
}
