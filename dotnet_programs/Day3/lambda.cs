using System;

public class Example
{
//    public static int Square(int x)
//     {
//         return x * x;
//     }

    public static void Exam()
    {
        Func<int, int> squareLambda = x => x * x;

        // Console.WriteLine(Square(4));
        Console.WriteLine(squareLambda(4));
    }
}
