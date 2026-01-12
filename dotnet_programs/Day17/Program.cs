using System;
using System.Diagnostics;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Trace.Listeners.Add(new ConsoleTraceListener());

        Trace.WriteLine("Program started");

        PerformCalculation(10, 5);
        PerformCalculation(10, 0);   // Error case

        Trace.WriteLine("Program ended");
    }

    static void PerformCalculation(int a, int b)
    {
        Trace.WriteLine($"Entering PerformCalculation | a={a}, b={b}");

        if (b == 0)
        {
            Trace.WriteLine("Error: Division by zero detected");
            return;
        }

        int result = Divide(a, b);

        Trace.WriteLine($"Calculation successful | Result={result}");
        Trace.WriteLine("Exiting PerformCalculation");
    }

    static int Divide(int x, int y)
    {
        Trace.WriteLine($"Dividing values | x={x}, y={y}");
        return x / y;
    }
}

 //***********************************************************************************************



// namespace MyApp
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             List<User> users = new List<User>();

//             users.Add(new User { Name = "Aryan", Age = 22 });
//             users.Add(new User { Name = "Mohit", Age = 32 });
//             users.Add(new User { Name = "Sushant", Age = 68 });
//             users.Add(new User { Name = "Ritik", Age = 63 });
//             users.Add(new User { Name = "Sahil", Age = 52 });

//             foreach (var user in users)
//             {
//                 Console.WriteLine($"User Name: {user.Name}, User Age: {user.Age}");
//             }

//             Console.WriteLine();

//             Queue<int> queue = new Queue<int>();
//             queue.Enqueue(45);
//             queue.Enqueue(55);
//             queue.Enqueue(65);
//             queue.Enqueue(75);
//             queue.Enqueue(25);

//             while (queue.Count > 0)
//             {
//                 Console.Write(queue.Dequeue() + " ");
//             }

//             Console.WriteLine();
//         }
//     }
// }
