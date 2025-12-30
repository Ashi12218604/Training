using System;
class NewCalculator
{
    static int a = 4;
    static int b = 5;
    static int num = 6;
    public static void calculate()
    {

        static int add(int a, int b)
        {
            Console.WriteLine(num);
            return a + b;
        }

        int addition = add(a, b);
        Console.WriteLine("Addition of a and b: " + addition);
    }
}
// static method cannot called non static methods
// static methods is c# is only declared at class level and not at method level `` Important``