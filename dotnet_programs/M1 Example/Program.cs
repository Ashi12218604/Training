// using System;
// using System.Collections.Generic;

// public class Program
// {
//     public static Stack<Order> OrderStack { get; set; } = new Stack<Order>();

//     public static void Main(string[] args)
//     {
//         Order obj = new Order();

//         int orderId = Convert.ToInt32(Console.ReadLine());
//         string customerName = Console.ReadLine();
//         string item = Console.ReadLine();

//         obj.AddOrderDetails(orderId, customerName, item);

//         Console.WriteLine(obj.GetOrderDetails());

//         obj.RemoveOrderDetails();

//         if (OrderStack.Count == 0)
//         {
//             Console.WriteLine("No Orders");
//         }
//         else
//         {
//             foreach (Order o in OrderStack)
//             {
//                 Console.WriteLine(o.OrderId + " " + o.CustomerName + " " + o.Item);
//             }
//         }
//     }
// }


// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main(String[] args)
//     {
//         Dictionary<string, int> inventory = new Dictionary<string, int>
//         {
//             { "P101", 25 },
//             { "P102", 0 },
//             { "P103", 14 }
//         };

//         string inputCode = Console.ReadLine();
//         // TODO: Implement lookup and print result
//         if(inventory.ContainsKey(inputCode))
//         {
//             Console.WriteLine(inventory[inputCode]);
//         }
//     else
//         {
//             Console.WriteLine("Not found");
//         }


//     }
// }

//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main()
//    {
//        Dictionary<string, int> marks = new Dictionary<string, int>
//        {
//            { "Asha", 78 },
//            { "Bala", 82 }
//        };

//        string student = Console.ReadLine();
//        int newMark = int.Parse(Console.ReadLine());
//        // TODO: Add or update mark
//        if(marks.ContainsKey(student))
//        {
//            marks[student]=newMark;
//        }
//        else

//        {
//            marks.Add(student,newMark);
//        }
//        Console.WriteLine(marks[student]);
//    }
//}

//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main()
//    {
//        int[] employeeIds = { 1001, 1002, 1001, 1003, 1002, 1001 };
//        Dictionary<int, int> attendance = new Dictionary<int, int>();

//        // Build frequency map
//        foreach (int id in employeeIds)
//        {
//            if (attendance.ContainsKey(id))
//            {
//                attendance[id]++;
//            }
//            else
//            {
//                attendance[id] = 1;
//            }
//        }

//        // Print result
//        foreach (var v in attendance)
//        {
//            Console.WriteLine($"Employee {v.Key} : {v.Value}");
//        }
//        Console.ReadLine();

//    }
//}


//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main()
//    {
//        string[] attempts = { "raj", "kavi", "raj", "raj", "kavi" };
//        Dictionary<string, int> failedAttempts = new Dictionary<string, int>();
//       foreach(string a in attempts)
//        {
//           if(failedAttempts.ContainsKey(a))
//            {
//                failedAttempts[a]++;
//            }
//            else
//            {
//                failedAttempts[a] = 1;
//            }
//        }
//       foreach(var v in failedAttempts)
//        {
//            if(v.Value>=3)
//            {
//                Console.WriteLine(v.Key);
//            }
//        }
//       Console.ReadLine();
//        // TODO: Count attempts and print users with attempts >= 3
//    }
//}



// C# Program to remove elements
// from a stack
using System;
using System.Collections.Generic;

class Geeks
{
    public static void Main(string[] args)
    {
        // Initialize a stack
        Stack<string> s = new Stack<string>();

        // Inserting elements into the s using Push()
        s.Push("Geeks");
        s.Push("For");
        s.Push("Geeks");
        s.Push("For");

        // Initial stack
        Console.WriteLine("Initial stack: ");
        foreach (var item in s)
        {
            Console.WriteLine(item);
        }

        // Removing the top element 
        // from the stack
        s.Pop();

        // Final s after removal
        Console.WriteLine("\nUpdated stack after Pop:");
        foreach (string item in s)
        {
            Console.WriteLine(item);
        }
        Console.ReadLine();
    }
}