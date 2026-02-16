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

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> marks = new Dictionary<string, int>
        {
            { "Asha", 78 },
            { "Bala", 82 }
        };

        string student = Console.ReadLine();
        int newMark = int.Parse(Console.ReadLine());
        // TODO: Add or update mark
        if(marks.ContainsKey(student))
        {
            marks[student]=newMark;
        }
        else

        {
            marks.Add(student,newMark);
        }
        Console.WriteLine(marks[student]);
    }
}